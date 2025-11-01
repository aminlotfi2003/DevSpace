using DevSpace.SharedKernel.Extensions;
using System.Diagnostics;

namespace DevSpace.Application.Common.Models.Results;

public class ApiResult
{
    public bool IsSuccess { get; set; }
    public ApiResultStatusCode StatusCode { get; set; }

    public string Message { get; set; }
    public string RequestId { get; }

    public ApiResult(bool isSuccess, ApiResultStatusCode statusCode, string message)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Message = message ?? statusCode.ToDisplay();
        RequestId = Activity.Current?.TraceId.ToHexString() ?? string.Empty;
    }
}

public class ApiResult<TData> : ApiResult
{
    public TData Data { get; set; }

    public ApiResult(bool isSuccess, ApiResultStatusCode statusCode, TData data, string message)
        : base(isSuccess, statusCode, message) => Data = data;
}
