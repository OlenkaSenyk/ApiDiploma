using System.Net;

namespace api_diploma.Data
{
    public class APIResponse
    {
        public APIResponse()
        {
            ErrorMsgs = new List<string>();
        }
        public HttpStatusCode StatusCode {  get; set; }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public List<string> ErrorMsgs { get; set; }
    }
}
