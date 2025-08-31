namespace TrainMateServer.Application.Errors
{
    public class BusinessException : Exception
    {
        public int ErrorCode { get; }

        public BusinessException(int errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}
