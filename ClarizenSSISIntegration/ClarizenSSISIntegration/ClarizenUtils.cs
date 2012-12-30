using System;
using System.Collections.Generic;
using System.Configuration;
using ClarizenSSISIntegration.ApiClarizenProxy;

namespace ClarizenSSISIntegration
{
    public class ClarizenUtils
    {
        private readonly Clarizen ClarizenAPI;
        private Dictionary<string, EntityDescription >projectEntityDescription;

        public ClarizenUtils()
            : this(ConfigurationManager.AppSettings["username"],
                   ConfigurationManager.AppSettings["pass"],
                   int.Parse(ConfigurationManager.AppSettings["clarizenTimeout"]))
        {
        }

        public ClarizenUtils(string username, string password, int timeout)
        {
            ClarizenAPI = new Clarizen {EnableDecompression = true, Timeout = timeout};
            var options = new LoginOptions
                              {
                                  PartnerId = "",
                                  ApplicationId = "E000D035-3F63-4D51-87BA-737EE9B1487E"
                              };

            ClarizenAPI.Login(username, password, options);
            projectEntityDescription=new Dictionary<string, EntityDescription>();
        }


//        public void RetrieveTask(string taskId)
//        {
//            var retrieveMsg = new RetrieveMessage();
//            retrieveMsg.Id = new EntityId();
//            retrieveMsg.Id.TypeName = "Task";
//            retrieveMsg.Id.Value = taskId;
////Retrieve only the fields you need.
//            retrieveMsg.Fields = new[] {"Name", "StartDate"};
//            var messages = new BaseMessage[] {retrieveMsg};
////Send the retrieve message to the server and cast the result to correct type
//            var result = (RetrieveResult) ClarizenAPI.Execute(messages)[0];

//            /*      List<BaseEntity> entities = new List<BaseEntity>();
//            // query
//            EntityQuery qry = new EntityQuery();

//            //from
//            qry.TypeName = "Task";

//            //select 
//            qry.Fields = new string[] { 
//                                     "Project"
//                                     ,"Parent"
//                                    ,"Manager"
//                                    ,"FixedCost"
//                                    ,"Work"
//                                    ,"Name"
//                                    ,"State.Name"
//                                    };

//            qry.Paging = new Paging() { PageSize = 500, PageSizeSpecified = true };
//            QueryResult queryResult = ClarizenAPI.Query(qry);


//            //Create the retrieve message
//            var retrieveMsg = new RetrieveMessage
//                                  {
//                                      Id = new EntityId {TypeName = "Task", Value = taskId},
//                                      Fields = new[] {"Name", "StartDate"}
//                                  };
//            //Retrieve only the fields you need.
//            var messages = new BaseMessage[] {retrieveMsg};
//            //Send the retrieve message to the server and cast the result to correct type
//            var result = (RetrieveResult) ClarizenAPI.Execute(messages)[0];
//            //Always check the result status
//          */
//            if (result.Success)
//            {
//                //Cast the returned entity to GenericEntity
//                var task = (GenericEntity) result.Entity;
//                //Now you can access the specific fields that were retrieved
//                var taskName = (string) task.Values[0].Value;
//                var startDate = (DateTime) task.Values[1].Value;
//            }
//        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal QueryResult RunQuery(EntityQuery qry)
        {
            return ClarizenAPI.Query(qry);
        }

        public EntityDescription GetMetaDataFields(string entityType)
        {
            if (!projectEntityDescription.ContainsKey(entityType))
            {
                var entity = new DescribeEntitiesMessage { TypeNames = new[] { entityType } };
                var entityDetails =
                    (DescribeEntitiesResult) ClarizenAPI.Metadata(entity);
                if (entityDetails.Success)
                    projectEntityDescription.Add(entityType, entityDetails.EntityDescriptions[0]);
            }
            return projectEntityDescription[entityType];
        }

        internal Result ExecuteQuery(BaseMessage[] baseMessage)
        {
            return ClarizenAPI.Execute(baseMessage)[0]; ;
        }
    }
}