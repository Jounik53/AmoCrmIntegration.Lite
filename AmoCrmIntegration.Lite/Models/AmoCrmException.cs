using System;

namespace AmoCrmIntegration.Lite.Models
{
    /// <summary>
    /// Type of class result request in CRM
    /// </summary>
    public class AmoCrmResult
    {
        public bool Success { get; set; }
        public string Content { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// Type of class exception in CRM
    /// </summary>
    public class AmoCrmException : Exception
    {
        public string ErrorCode { get; set; }

        public AmoCrmException(string message, string errorCode) : base(message)
        {
        }
    }

}
