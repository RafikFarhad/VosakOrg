using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace VosakOrgWeb.Response
{
    [DataContract]
    public class ApiResponse
    {
        [DataMember(Name = "status")]
        private int StatusCode { get; set; }
        
        // [DataMember(Name = "version")]
        // public string Version => "1.0";

        [DataMember(Name = "errorMessage", EmitDefaultValue = false)]
        private string ErrorMessage { get; set; }

        [DataMember(Name = "data", EmitDefaultValue = false)]
        private object Result { get; set; }

        public ApiResponse(int statusCode, object result, string errorMessage)
        {
            StatusCode = statusCode;
            Result = result;
            ErrorMessage = errorMessage;
        }

        public static ApiResponse SuccessResponse(object result = null, int statusCode = 200)
        {
            result ??= "Success";
            return new ApiResponse(statusCode, result, null);
        }
        
        public static ApiResponse ErrorResponse(string errorMessage = "Something Went Wrong!", int statusCode = 400)
        {
            return new ApiResponse(statusCode, null, errorMessage);
        }

        public static ApiResponse NotFoundResponse(string errorMessage = "Content Not Found.", int statusCode = 404)
        {
            return new ApiResponse(statusCode, null, errorMessage);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}