namespace FirstWebApi.Exceptions
{

    public enum CrudExceptionType
    {
        NotFound, Conflict
    }

    [Serializable]
    public class CrudException : Exception
    {
        public CrudExceptionType ErrorType { get; }
        public CrudException() { }
        public CrudException(string message, CrudExceptionType type) : base(message)
        {
            this.ErrorType = type;
        }
        public CrudException(string message, Exception inner) : base(message, inner) { }
        protected CrudException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
