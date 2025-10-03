using FluentResults;

namespace BillingSystem.Api.Common;

public static class ErrorMessage
{
    public static string GetErrorMessage(Result result) =>
        string.Join(", ", result.Errors.Select(u => u.Message));
}