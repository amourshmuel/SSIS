/* Microsoft SQL Server Integration Services Script Component
*  Write scripts using Microsoft Visual C# 2008.
*  ScriptMain is the entry point class of the script.*/

using System;
using System.Data;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;
using SC_9628c536e417425994a0bfc1f6595d6c.csproj.com.clarizen.api1;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

[Microsoft.SqlServer.Dts.Pipeline.SSISScriptComponentEntryPointAttribute]
public class ScriptMain : UserComponent
{
    private Clarizen clarizenClient;
    string userId;

    public override void PreExecute()
    {
        base.PreExecute();
        /// login
        string username = Variables.ClarizenUserName;
        string password = Variables.ClarizenPassword;

        clarizenClient = new Clarizen();
        clarizenClient.Timeout = 10 * 1000 * 60; //For debugging
        clarizenClient.EnableDecompression = true; //compress traffic

        //Currently pass null in last argument
        LoginOptions options = new LoginOptions();

        //If you are an enterprise user, leave the partnerId empty. If you are a certified partner, please
        //place the partner id you received from Clarizen here:
        options.PartnerId = "";
        options.ApplicationId = "ClarizenClient"; //Replace with a string representing your application

        LoginResult lr = clarizenClient.Login(username, password, options);
        userId = lr.UserId;
    }

    public override void PostExecute()
    {
        base.PostExecute();
        /*
          Add your code here for postprocessing or remove if not needed
          You can set read/write variables here, for example:
          Variables.MyIntVar = 100
        */
    }

    public static void CheckResult(Result qr)
    {
        if (!qr.Success)
            throw new Exception(qr.Error.Message);
    }

    public override void CreateNewOutputRows()
    {
        List<BaseEntity> entities = new List<BaseEntity>();
        // query
        EntityQuery qry = new EntityQuery();

        //from
        qry.TypeName = "Task";

        //select 
        qry.Fields = new string[] { 
                                     "Project"
                                     ,"Parent"
                                    ,"C_Program.Name"
                                    ,"Manager"
                                    ,"FixedCost"
                                    ,"Work"
                                    ,"Name"
                                    ,"State.Name"
                                    };

        qry.Paging = new Paging() { PageSize = 500, PageSizeSpecified = true };
        QueryResult queryResult = clarizenClient.Query(qry);
        CheckResult(queryResult);
        
        entities.AddRange(queryResult.Entities);

        while (queryResult.Paging.HasMore)
        {
            qry.Paging = queryResult.Paging;
            queryResult = clarizenClient.Query(qry);
            entities.AddRange(queryResult.Entities);
        }
        

        Dictionary<string,string> result = new Dictionary<string,string>();
        decimal dec;
        int intval;
        DateTime dt;
        foreach (GenericEntity ge in entities)
        {
            result.Clear();
            result.Add("Id", ge.Id.Value.ToString());

            foreach (FieldValue fv in ge.Values)
            {
                FieldValueToString(result, fv);
            }
            Output0Buffer.AddRow();
            if (result.ContainsKey("Project.Id"))
            {
                Output0Buffer.ProjectId = result["Project.Id"];
            }
            if (result.ContainsKey("Parent.Id"))
            {
                Output0Buffer.ParentId = result["Parent.Id"];
            }
            if (result.ContainsKey("Id"))
            {
                Output0Buffer.TaskId = result["Id"];
            }
            if (result.ContainsKey("C_Program.Name"))
            {
                Output0Buffer.CProgram = result["C_Program.Name"];
            }
            if (result.ContainsKey("Manager.Id"))
            {
                Output0Buffer.ManagerId = result["Manager.Id"];
            }
            if (result.ContainsKey("Name"))
            {
                Output0Buffer.Name = result["Name"];
            }

            if (result.ContainsKey("State.Name"))
            {
                Output0Buffer.State = result["State.Name"];
            }

            if (result.ContainsKey("Work.Value"))
            {
                if (int.TryParse(result["Work.Value"], out intval))
                {
                    Output0Buffer.Work = intval;
                }
            }

            if (result.ContainsKey("FixedCost.Value"))
            {
                if (int.TryParse(result["FixedCost.Value"], out intval))
                {
                    Output0Buffer.FixedCost = intval;
                }
            }

        }
    }

    public static void FieldValueToString(Dictionary<string,string> results, FieldValue fieldValue)
    {
        FieldValueToString(results , "", fieldValue);
    }

    public static void FieldValueToString(Dictionary<string, string> results, string Path, FieldValue fieldValue)
    {
        if (fieldValue == null)
        {
            return;
        }
        if (fieldValue.Value == null)
        {
            results.Add(Path + fieldValue.FieldName, "null");
            return;
        }

        if (fieldValue.Value is BaseEntity)
        {
            GenericEntity ge = (GenericEntity)fieldValue.Value;
            results.Add(Path + fieldValue.FieldName + ".Id", ge.Id.Value.ToString());
            StringBuilder result = new StringBuilder(ge.Id.Value);
            if (ge.Values.Length > 0)
            {
                //recursive
                foreach (FieldValue fv in ge.Values)
                {
                    FieldValueToString(results, Path + fieldValue.FieldName + ".", fv);
                }
            }
            return;
        }
        else if (fieldValue.Value is Duration)
        {
            Duration duration = fieldValue.Value as Duration;
            results.Add(Path + fieldValue.FieldName + ".Value", duration.Value.ToString());
            results.Add(Path + fieldValue.FieldName + ".Unit", duration.Unit.ToString());
            return;
        }
        else if (fieldValue.Value is Money)
        {
            Money money = fieldValue.Value as Money;
            results.Add(Path + fieldValue.FieldName + ".Value", money.Value.ToString());
            results.Add(Path + fieldValue.FieldName + ".Currency", money.Currency.ToString());
            return;
        }
        else if (fieldValue.Value is DateTime)
        {
            DateTime dt = (DateTime)fieldValue.Value;
            dt = dt.ToLocalTime();
            results.Add(Path + fieldValue.FieldName, dt.ToString());
            return;
        }
        else
        {
            results.Add(Path + fieldValue.FieldName, fieldValue.Value.ToString());
            return;
        }
    }


}
