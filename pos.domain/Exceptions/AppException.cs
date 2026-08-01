
namespace pos.domain.Exceptions
{
    public abstract class AppException : Exception
    {
        public abstract int StatusCode { get; }
        public abstract string Title { get; }

        protected AppException(string message) : base(message) { }
        protected AppException(string message, Exception innerException) : base(message, innerException) { }
    }
}
