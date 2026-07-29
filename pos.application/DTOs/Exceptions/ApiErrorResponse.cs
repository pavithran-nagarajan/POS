using System;
using System.Collections.Generic;
using System.Text;

namespace pos.application.DTOs.Exceptions
{
    public class ApiErrorResponse
    {
        public string TraceId { get; set; } = string.Empty;
        public int Status { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Detail { get; set; }
        public string Instance { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public Dictionary<string, string[]>? Errors { get; set; } // validation errors only
    }
}
