namespace Core.LLama.Common
{
    public class ServiceResult<T> : ServiceResult, IServiceResult<T>
    {
        public T? Value { get; set; }
    }
    public class ServiceResult
    {
        public String Error { get; set; } = String.Empty;
        public Boolean HasError
        {
            get { return !String.IsNullOrEmpty(Error); }
        }
        public static IServiceResult<T> FromValue<T>(T value)
        {
            return new ServiceResult<T>
            {
                Value = value,
            };
        }
        public static IServiceResult<T> FromError<T>(String error)
        {
            return new ServiceResult<T>
            {
                Error = error,
            };
        }
    }
    public interface IServiceResult<T>
    {
        T? Value { get; set; }
        String Error { get; set; }
        Boolean HasError { get; }
    }
}
