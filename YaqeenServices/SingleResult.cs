using FluentValidation.Results;

namespace YaqeenServices
{
    public class SingleResult<T> 
    {
        public bool IsValidationError { get; }
        public T Value { get;}
        public IList<string> ErrorMessages { get; }
        public SingleResult(T value) 
        {
            Value = value;
        }
        public SingleResult(ValidationResult validationResult)
        {
            ErrorMessages = validationResult.Errors?.Select(s => s.ErrorCode).ToList() ?? new List<string>();
            IsValidationError = true;
        }
        public SingleResult(string errorMessage)
        {
            ErrorMessages = new List<string>() { errorMessage};
        }
        public bool Success => !ErrorMessages?.Any() ?? true;
    }
}
