using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiMicroservice.Auth.Entities
{
    public class ApiResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object ApiObject { get; set; }

        public ApiResult(bool status, string message, object apiObject = null)
        {
            this.Status = status;
            this.Message = message;
            this.ApiObject = apiObject;
        }

        public ApiResult(bool status, object apiObject)
        {
            this.Status = status;
            this.ApiObject = apiObject;
        }

        public ApiResult(bool status, Exception ex)
        {
            this.Status = status;
            this.Message = $"{ex.Message}";
        }
    }
}
