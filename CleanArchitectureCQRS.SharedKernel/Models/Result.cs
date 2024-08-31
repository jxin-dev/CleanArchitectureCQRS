namespace CleanArchitectureCQRS.SharedKernel.Models
{
    public class Result
    {
        public Result(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        public static Result Success()
        {
            return new Result(true, null!);
        }
        public static Result Failure(Error error)
        {
            return new Result(false, error);
        }

        public static Result<TValue> Success<TValue>(TValue value)
        {
            return new Result<TValue>(value, true, null!);
        }

        public static Result<TValue> Failure<TValue>(Error error)
        {
            return new Result<TValue>(default!, false, error);
        }

    }

    public class Result<TValue> : Result
    {
        public TValue Value { get; set; }
        public Result(TValue value, bool isSuccess, Error error) 
            : base(isSuccess, error)
        {
            Value = value;
        }
    }

}
