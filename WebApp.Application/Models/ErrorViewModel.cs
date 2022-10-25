using System;

namespace WebApp.Application.Models
{
    public class ErrorViewModel
    {
        public string RequestId { set; get; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
