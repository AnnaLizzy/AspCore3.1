namespace WebApp.ViewModels.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidatetionErrors { get; set; }
        public ApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;

        }
        public ApiErrorResult(string[] validatetionErrors)
        {
            IsSuccessed = false;
            ValidatetionErrors = validatetionErrors;

        }
        public ApiErrorResult()
        {
            IsSuccessed=false;
         
        }
     
      
    }
}
