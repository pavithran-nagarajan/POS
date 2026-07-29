using System;
using System.Collections.Generic;
using System.Text;

namespace pos.domain.Exceptions
{
    public class ValidationAppException : AppException
    {
        public override int StatusCode => 400;
        public override string Title => "Validation error";
        public IDictionary<string, string[]> Errors { get; }

        public ValidationAppException(IDictionary<string, string[]> errors)
            : base("One or more validation errors occurred.")
        {
            Errors = errors;
        }
    }
}
