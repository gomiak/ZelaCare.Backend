namespace ZelaCare.Application.Models
{
    public class ResultViewModel
    {
        protected ResultViewModel(bool isSuccess = true, string message = "", IEnumerable<string>? errors = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Errors = errors?.ToList() ?? new List<string>();
        }

        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public List<string> Errors { get; private set; }

        public bool HasErrors => Errors.Any();
        public string FullMessage => HasErrors ? string.Join(" | ", Errors) : Message;

        public static ResultViewModel Success() => new();

        public static ResultViewModel Error(string message) =>
            new ResultViewModel(false, message, new[] { message });

        public static ResultViewModel Error(IEnumerable<string> errors) =>
            new ResultViewModel(false, "Validation errors.", errors);

        public void AddError(string message)
        {
            IsSuccess = false;
            Errors.Add(message);
        }

        public void AddErrors(IEnumerable<string> messages)
        {
            IsSuccess = false;
            Errors.AddRange(messages);
        }
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public ResultViewModel(T? data, bool isSuccess = true, string message = "", IEnumerable<string>? errors = null)
            : base(isSuccess, message, errors)
        {
            Data = data;
        }

        public T? Data { get; private set; }

        public static ResultViewModel<T> Success(T data, string message = "") =>
            new(data, true, message);

        public static ResultViewModel<T> Error(string message) =>
            new(default, false, message, new[] { message });

        public static ResultViewModel<T> Error(IEnumerable<string> errors) =>
            new(default, false, "Validation errors.", errors);
    }
}
