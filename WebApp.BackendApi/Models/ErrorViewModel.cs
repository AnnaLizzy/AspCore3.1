namespace WebApp.BackendApi.Models
{
    public class ErrorViewModel
    {
        public string RequestId { set; get; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
