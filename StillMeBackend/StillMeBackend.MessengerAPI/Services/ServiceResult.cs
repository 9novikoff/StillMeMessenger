namespace StillMeBackend.MessengerAPI.Services;

public class ServiceResult<T>
{
    public T? Value { get; set; }
    public bool IsValid { get; set;}
    public string? ErrorMessage { get; set; }

    public static implicit operator ServiceResult<T>(T value) =>
        new ServiceResult<T>() { Value = value, IsValid = true };
    
    public static implicit operator ServiceResult<T>(string errorMessage) =>
        new ServiceResult<T>() { ErrorMessage = errorMessage, IsValid = false };
    
    public static implicit operator ServiceResult<T>(bool value) =>
        new ServiceResult<T>() { IsValid = value };

    public TResult Match<TResult>(Func<T, TResult> success, Func<string, TResult> fail)
    {
        return IsValid ? success(Value) : fail(ErrorMessage);
    }
}