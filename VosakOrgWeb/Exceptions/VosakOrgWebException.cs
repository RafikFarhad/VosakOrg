using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace VosakOrgWeb.Exceptions
{
    public class VosakOrgWebException : Exception
        {
            public HttpStatusCode StatusCode { get; }
            
            public string ContentType { get; set; } = "application/json";

            public VosakOrgWebException(HttpStatusCode statusCode)
            {
                this.StatusCode = statusCode;
            }

            public VosakOrgWebException(HttpStatusCode statusCode, string message = "Something went wrong!") : base(message)
            {
                this.StatusCode = statusCode;
            }

            public VosakOrgWebException(HttpStatusCode statusCode, Exception inner) : this(statusCode, inner.ToString())
            {
                
            }

            public VosakOrgWebException(HttpStatusCode statusCode, JObject errorObject) : this(statusCode, errorObject.ToString())
            {
                
            }
        
    }
}