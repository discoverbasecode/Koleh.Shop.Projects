namespace Framework.Application.Results;

public class OperationResult<TData>
{
    public const string SuccessMessage = "عملیات با موفقیت انجام شد";
    public const string NotFoundMessage = "اطلاعات یافت نشد";
    public const string ErrorMessage = "عملیات با شکست مواجه شد";

    public string Message { get; set; }
    public string? Title { get; set; }
    public OperationResultStatus Status { get; set; }
    public TData? Data { get; set; }

    public static OperationResult<TData> Success(TData data, string? message = null)
    {
        return new OperationResult<TData>
        {
            Status = OperationResultStatus.Success,
            Message = message ?? SuccessMessage,
            Data = data,
        };
    }

    public static OperationResult<TData> NotFound(string? message = null)
    {
        return new OperationResult<TData>
        {
            Status = OperationResultStatus.NotFound,
            Message = message ?? NotFoundMessage,
            Data = default,
        };
    }

    public static OperationResult<TData> Error(string? message = null)
    {
        return new OperationResult<TData>
        {
            Status = OperationResultStatus.Error,
            Message = message ?? ErrorMessage,
            Data = default,
        };
    }
}

public class OperationResult
{
    public const string SuccessMessage = "عملیات با موفقیت انجام شد";
    public const string NotFoundMessage = "اطلاعات یافت نشد";
    public const string ErrorMessage = "عملیات با شکست مواجه شد";

    public string Message { get; set; } = string.Empty;
    public string? Title { get; set; }
    public OperationResultStatus Status { get; set; }

    public static OperationResult Success(string? message = null)
    {
        return new OperationResult
        {
            Status = OperationResultStatus.Success,
            Message = message ?? SuccessMessage,
        };
    }

    public static OperationResult NotFound(string? message = null)
    {
        return new OperationResult
        {
            Status = OperationResultStatus.NotFound,
            Message = message ?? NotFoundMessage,
        };
    }

    public static OperationResult Error(string? message = null, OperationResultStatus status = OperationResultStatus.Error)
    {
        return new OperationResult
        {
            Status = status,
            Message = message ?? ErrorMessage,
        };
    }
}

public enum OperationResultStatus
{
    Error = 10,
    Success = 200,
    NotFound = 404
}