namespace Core.Helpers
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data, List<string> messagelist) : base(data, false, messagelist)
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        public ErrorDataResult(List<string> messagelist) : base(default, false, messagelist)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
