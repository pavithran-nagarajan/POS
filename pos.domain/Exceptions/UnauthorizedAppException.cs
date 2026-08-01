
namespace pos.domain.Exceptions
{
    public class UnauthorizedAppException : AppException
    {
        public override int StatusCode => 401;
        public override string Title => "Unauthorized";

        public UnauthorizedAppException(string message) : base(message) { }
    }
}
