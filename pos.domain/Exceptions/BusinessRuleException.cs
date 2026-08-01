
namespace pos.domain.Exceptions
{
    public class BusinessRuleException : AppException
    {
        public override int StatusCode => 422;
        public override string Title => "Business rule violation";

        public BusinessRuleException(string message) : base(message) { }
    }
}
