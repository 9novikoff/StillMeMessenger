namespace StillMeBackend.MessengerAPI.Services;

public interface IService<T>
{
    public Task<ServiceResult<T>> AddAsync(T entity);
    public IEnumerable<T> GetAll();
    public Task<ServiceResult<T>> GetByIdAsync(object id);
    public Task<ServiceResult<T>> UpdateAsync(object id, T city);
    public Task<ServiceResult<T>> DeleteAsync(object id);
}