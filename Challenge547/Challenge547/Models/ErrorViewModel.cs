using System;

namespace Challenge547.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    
    public class Dashboard
    {
        public DateTime dateTime { get; set; }
    }
}
