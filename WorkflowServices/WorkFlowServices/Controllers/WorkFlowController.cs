using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using WorkFlowServices.Models;

namespace WorkFlowServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WorkFlowController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("GET: Test message")
            };
        }

        public HttpResponseMessage Post()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("POST: Test message")
            };
        }

        public HttpResponseMessage Put()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("PUT: Test message")
            };
        }

        public IHttpActionResult GetCommands()
        {
            var values = new List<string>() { "abc", "def" };
            return Ok(new { data = values, success = true, error = "", message = "" });
        }

        [HttpGet]
        public IHttpActionResult Conditions()
        {
            var conditions = new List<string>() { "IsManagerApprovalNeeded" };
            return Ok(new { data = conditions, success = true, error = "", message = "" });
        }

        [HttpGet]
        public IHttpActionResult Rules()
        {
            List<string> rules = new List<string>() { "IsAuthorized", "IsSelf" };
            return Ok(new { data = rules, success = true, error = "", message = "" });
        }

        [HttpGet]
        public IHttpActionResult Roles()
        {
            using (wfe_sampleEntities entities = new wfe_sampleEntities())
            {
                var roles = entities.Roles.Select(r => r.Name).ToList();
                return Ok(new { data = roles, success = true, error = "", message = "" });
            }
        }

        [HttpGet, HttpPost]
        public IHttpActionResult Identities(ExecuteParameters executeParameters)
        {
            using (wfe_sampleEntities entities = new wfe_sampleEntities())
            {
                var identities = entities.Employees.Where(e => e.Role.Name == executeParameters.Name).Select(s => s.Name).ToList();
                return Ok(new { data = identities, success = true, error = "", message = "" });
            }
        }

        [HttpGet]
        public IHttpActionResult Users()
        {
            using (wfe_sampleEntities entities = new wfe_sampleEntities())
            {
                var users = entities.Employees.ToList();
                return Ok(new { data = users, success = true, error = "", message = "" });
            }
        }

        [HttpPost]
        public IHttpActionResult ExecuteRuleCheck([FromBody]ExecuteParameters executeParameters)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Type type = executingAssembly.GetType("WorkFlowServices.Controllers.HelperMethods");
            MethodInfo mInfo = type.GetMethod(executeParameters.Name);
            ParameterInfo[] parameters = mInfo.GetParameters();
            object classInstance = Activator.CreateInstance(type, null);

            object result = null;
            if (parameters.Length == 0)
            {
                result = mInfo.Invoke(classInstance, null);
            }
            else
            {
                string userId = executeParameters.IdentityId;
                Guid processId = executeParameters.ProcessInstance.Id.Value;
                object[] paramsArray = new object[parameters.Length];

                if (executeParameters.Name == "IsAuthorized")
                {
                    paramsArray[0] = userId;
                }
                else
                {
                    paramsArray[0] = userId;
                    paramsArray[1] = processId;
                }
                
                result = mInfo.Invoke(classInstance, paramsArray);
            }

            return Ok(new { data = Convert.ToBoolean(result), success = true, error = "", message = "" });
        }

        [HttpPost]
        public IHttpActionResult ExecuteCondition(ExecuteParams executeParams)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Type type = executingAssembly.GetType("WorkFlowServices.Controllers.HelperMethods");
            MethodInfo mInfo = type.GetMethod(executeParams.Name);
            ParameterInfo[] parameters = mInfo.GetParameters();
            object classInstance = Activator.CreateInstance(type, null);

            object result = null;
            if (parameters.Length == 0)
            {
                result = mInfo.Invoke(classInstance, null);
            }
            else
            {
                //var abc = executeParams.ProcessInstance.GetParameter<int>(executeParams.Parameter);
                //int leaveDays = 0;//Convert.ToInt32(processInstance.GetParameter("LeaveDays").Value);
                var leaveDays = (long)executeParams.ProcessInstance.ProcessParameters["leaveDays"]; //JSON deserialization artifact. The names starts from lower case
                var autoApprovedLeaveDays = (long)executeParams.ProcessInstance.ProcessParameters["autoApprovedLeaveDays"];

                object[] paramsArray = new object[] { executeParams.ProcessInstance.RootProcessId };
                result = mInfo.Invoke(classInstance, paramsArray);
            }

            return Ok(new { data = Convert.ToBoolean(result), success = true, error = "", message = "" });
        }

        [HttpGet]
        public List<Guid> GetNonFinalizedInstances(string schemeCode)
        {
            var entities = new wfe_sampleEntities();
            var schemeId = entities.WorkflowProcessSchemes.FirstOrDefault(w => w.SchemeCode == schemeCode && w.IsObsolete == false).Id;
            return entities.WorkflowProcessInstances.Where(w => w.SchemeId == schemeId && w.StateName != "Final").Select(s => s.Id).ToList();
        }
    }

    public class HelperMethods
    {
        public bool IsManagerApprovalNeeded(Guid processId)
        {
            using (wfe_sampleEntities entities = new wfe_sampleEntities())
            {
                var processParams = entities.WorkflowProcessInstancePersistences.Where(w => w.ProcessId == processId);
                var autoApprovedLeaveDays = Convert.ToInt32(processParams.FirstOrDefault(p => p.ParameterName == "AutoApprovedLeaveDays").Value);
                var appliedLeaveDays = Convert.ToInt32(processParams.FirstOrDefault(p => p.ParameterName == "LeaveDays").Value);
                return appliedLeaveDays > autoApprovedLeaveDays;
            }
        }

        public bool IsUser(string userId)
        {
            using (wfe_sampleEntities entities = new wfe_sampleEntities())
            {
                var user = entities.Employees.FirstOrDefault(e => e.Name == userId && e.Role.Name == "User");
                return user != null;
            }
        }

        public bool IsAuthorized(string userId)
        {
            using (wfe_sampleEntities entities = new wfe_sampleEntities())
            {
                var user = entities.Employees.FirstOrDefault(e => e.Name == userId && (e.Role.Name == "Manager" || e.Role.Name == "Admin"));
                return user != null;
            }
        }

        public bool IsSelf(string userId, Guid processId)
        {
            using (wfe_sampleEntities entities = new wfe_sampleEntities())
            {
                return entities.WorkflowProcessTransitionHistories.FirstOrDefault(h => h.ProcessId == processId && h.FromStateName == "Initial").ExecutorIdentityId == userId;
            }
        }

        private bool IsManager(string userId)
        {
            using (wfe_sampleEntities entities = new wfe_sampleEntities())
            {
                var user = entities.Employees.FirstOrDefault(e => e.Name == userId && e.Role.Name == "Manager");
                return user != null;
            }
        }

        private bool IsAdmin(string userId)
        {
            using (wfe_sampleEntities entities = new wfe_sampleEntities())
            {
                var user = entities.Employees.FirstOrDefault(e => e.Name == userId && e.Role.Name == "Admin");
                return user != null;
            }
        }
    }

    public class ExecuteParams
    {
        public string Name;
        public string IdentityId;
        public string Parameter;
        public OptimaJet.WorkflowServer.Model.WorkflowProcessInstance ProcessInstance;
    }
}
