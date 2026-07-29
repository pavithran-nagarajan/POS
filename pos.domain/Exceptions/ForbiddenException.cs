using System;
using System.Collections.Generic;
using System.Text;

namespace pos.domain.Exceptions
{
    public class ForbiddenException : AppException
    {
        public override int StatusCode => 403;
        public override string Title => "Forbidden";

        public ForbiddenException(string message) : base(message) { }
    }
}
