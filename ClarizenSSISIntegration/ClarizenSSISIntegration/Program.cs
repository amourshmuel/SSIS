using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using ClarizenSSISIntegration.ApiClarizenProxy;
using ClarizenSSISIntegration.Properties;

namespace ClarizenSSISIntegration
{
    internal class Program
    {
        private static void Main()
        {
            var utils = new ClarizenUtils();

            string targetType = "Project";
            foreach (
                string csvReadFile in
                    Directory.GetFiles(ConfigurationManager.AppSettings["projectCsvDir"], "*.csv",
                                       SearchOption.TopDirectoryOnly))
            {
                try
                {
                    RunQuery(utils, csvReadFile, targetType);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("File:{0}\r\n{1}\r\n", csvReadFile, ex));
                }
            }

            targetType = "Task";
            foreach (
                string csvReadFile in
                    Directory.GetFiles(ConfigurationManager.AppSettings["tasksCsvDir"], "*.csv",
                                       SearchOption.TopDirectoryOnly))
            {
                try
                {
                    RunQuery(utils, csvReadFile, targetType);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("File:{0}\r\n{1}\r\n", csvReadFile, ex));
                }
            }

            targetType = "User";
            foreach (
                string csvReadFile in
                    Directory.GetFiles(ConfigurationManager.AppSettings["usersCsvDir"], "*.csv",
                                       SearchOption.TopDirectoryOnly))
            {
                try
                {
                    RunQuery(utils, csvReadFile, targetType);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("File:{0}\r\n{1}\r\n", csvReadFile, ex));
                }
            }

            targetType = "Task";
            foreach (
                string csvReadFile in
                    Directory.GetFiles(ConfigurationManager.AppSettings["updateTasksCsvDir"], "*.csv",
                                       SearchOption.TopDirectoryOnly))
            {
                UpdateTaskFields(utils, csvReadFile, targetType);
            }
        }

        private static void UpdateTaskFields(ClarizenUtils utils, string csvReadFile, string targetType)
        {
            try
            {
                using (var csv = new CsvParser(new StreamReader(csvReadFile)))
                {
                    int rowIndex = 0;
                    while (csv.ReadNextRecord())
                    {
                        foreach (string field in csv.HeaderFields)
                        {
                            if (field.Equals("TASKID", StringComparison.InvariantCultureIgnoreCase)) continue;

                            object newValue = ParseValue(csv.CurrentDic[field], field);

                            var task = new GenericEntity
                                           {
                                               Id =
                                                   new EntityId
                                                       {TypeName = targetType, Value = csv.CurrentDic["TASKID"]}
                                           };
                            //Create a FieldValue representing the Manager field
                            var managerField = new FieldValue {FieldName = field, Value = newValue};
                            //Set the field value to the external identifier of the new manager
                            task.Values = new[] {managerField};
                            var updateMsg = new UpdateMessage {Entity = task};
                            //Update the entity
                            Result result = utils.ExecuteQuery(new BaseMessage[] {updateMsg});


                            string dir = Path.GetDirectoryName(csvReadFile);
                            if (dir == null) throw new ArgumentNullException("csvReadFile");
                            dir = Path.Combine(dir, "Handled");
                            if (!Directory.Exists(dir))
                                Directory.CreateDirectory(dir);
                            string resultFileName = Path.Combine(dir,
                                                                 string.Format("{0}_Result_{1}.csv",
                                                                               Path.GetFileNameWithoutExtension(
                                                                                   csvReadFile),
                                                                               rowIndex));
                            string combineText = result.Success ? "Success" : "Failure";
                            File.WriteAllText(resultFileName, combineText);
                            string p = Path.GetDirectoryName(csvReadFile);
                            string d = Path.GetFileName(csvReadFile);
                            if (p != null)
                            {
                                if (d != null)
                                {
                                    string destFileName = Path.Combine(Path.Combine(p, "Handled"), d);
                                    if (File.Exists(destFileName))
                                        File.Delete(destFileName);
                                    File.Move(csvReadFile, destFileName);
                                }
                            }
                        }
                        rowIndex++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("File:{0}\r\n{1}\r\n", csvReadFile, ex));
            }
        }

        private static void RunQuery(ClarizenUtils utils, string csvReadFile, string targetType)
        {
            using (var csv = new CsvParser(new StreamReader(csvReadFile)))
            {
                int rowIndex = 0;
                while (csv.ReadNextRecord())
                {
                    var conditions = new List<Compare>();
                    foreach (string field in csv.HeaderFields)
                    {
                        if (string.IsNullOrEmpty(csv.CurrentDic[field])) continue;
                        var condition = new Compare
                                            {
                                                LeftExpression = new FieldExpression {FieldName = field},
                                                Operator = Operator.Equal,
                                                RightExpression = new ConstantExpression
                                                                      {
                                                                          Value =
                                                                              ParseValue(csv.CurrentDic[field],
                                                                                         field)
                                                                      }
                                            };
                        conditions.Add(condition);
                    }


                    var qry = new EntityQuery
                                  {
                                      TypeName = targetType,
                                      Where = GetWhereCondition(conditions),
                                      Fields = GetFieldsNames(utils.GetMetaDataFields(targetType).Fields)
                                  };


                    QueryResult queryResult = utils.RunQuery(qry);

                    if (!queryResult.Success) continue;
                    string dir = Path.GetDirectoryName(csvReadFile);
                    if (dir == null) throw new ArgumentNullException("csvReadFile");
                    dir = Path.Combine(dir, "Handled");
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    string resultFileName = Path.Combine(dir,
                                                         string.Format("{0}_Result_{1}.csv",
                                                                       Path.GetFileNameWithoutExtension(csvReadFile),
                                                                       rowIndex));
                    string heder = string.Empty;
                    string result = string.Empty;
                    string combineText;
                    if (queryResult.Entities.Length == 0)
                    {
                        combineText = "No Results";
                    }
                    else
                    {
                        for (int i = 0; i < queryResult.Entities.Length; i++)
                        {
                            foreach (FieldValue val in ((GenericEntity) queryResult.Entities[i]).Values)
                            {
                                if (i == 0)
                                    heder += val.FieldName + ",";
                                if (val.Value == null || val.Value.GetType() == typeof (GenericEntity))
                                    result += ",";

                                else if (val.Value.GetType() == typeof (Money))
                                    result += ((Money) val.Value).Value + " (" + ((Money) val.Value).Currency + "),";
                                else if (val.Value.GetType() == typeof (Duration))
                                    result += ((Duration) val.Value).Value + " (" + ((Duration) val.Value).Unit + "),";
                                else
                                    result += ClearNewLine(val.Value.ToString()) + ",";
                            }
                            if ((i + 1) < queryResult.Entities.Length)
                                result += "\r\n";
                        }

                        combineText = heder + "\r\n" + result;
                    }
                    File.WriteAllText(resultFileName, combineText);
                    rowIndex++;
                }
            }
            string p = Path.GetDirectoryName(csvReadFile);
            string d = Path.GetFileName(csvReadFile);
            if (p != null)
            {
                if (d != null)
                {
                    string destFileName = Path.Combine(Path.Combine(p, "Handled"), d);
                    if (File.Exists(destFileName))
                        File.Delete(destFileName);
                    File.Move(csvReadFile, destFileName);
                }
            }
        }

        private static string ClearNewLine(string value)
        {
            return value.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ").Replace(",", ";");
        }

        private static string[] GetFieldsNames(FieldDescription[] fields)
        {
            var returnValue = new string[fields.Length];
            for (int index = 0; index < fields.Length; index++)
            {
                returnValue[index] = fields[index].Name;
            }
            return returnValue;
        }


        private static Condition GetWhereCondition(List<Compare> conditions, bool andOperator = true)
        {
            if (conditions.Count == 1)
                return conditions[0];
            LogicalCondition result;
            if (andOperator)
                result = new And();
            else
                result = new Or();

            result.Conditions =(Condition[]) Convert.ChangeType( conditions.ToArray(),typeof(Condition[]));
            return result;
        }

        private static object ParseValue(string value, string fieldName)
        {
            string fieldType = Settings.Default[fieldName].ToString();
            Type @type = Type.GetType(fieldType);
            if (@type != null)
            {
                switch (@type.FullName)
                {
                    case "System.Boolean":
                        return bool.Parse(value);
                    case "System.DateTime":
                        return DateTime.Parse(value);
                    case "System.Double":
                        return Double.Parse(value);
                    case "System.Int32":
                    case "System.Int16":
                    case "System.Int64":
                        return long.Parse(value);
                    case "System.String":
                        return value;

                    default:
                        return value;
                }
            }
            return new EntityId {TypeName = fieldType, Value = value};
        }
    }
}