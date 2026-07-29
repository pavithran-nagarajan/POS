using System;
using System.Collections.Generic;
using System.Text;

namespace pos.domain.Exceptions
{
    public class NotFoundException : AppException
    {
        public override int StatusCode => 404;
        public override string Title => "Resource not found";

        public NotFoundException(string message) : base(message) { }
    }
}
