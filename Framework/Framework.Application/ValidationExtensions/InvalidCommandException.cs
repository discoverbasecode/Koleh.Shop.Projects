namespace Framework.Application.ValidationExtensions
{
    public class InvalidCommandException : Exception
    {
        public string? Details { get; }

        public InvalidCommandException()
        {
        }

        public InvalidCommandException(string message) : base(message)
        {
        }

        public InvalidCommandException(string message, string? details) : base(message)
        {
            Details = details;
        }

        public InvalidCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
