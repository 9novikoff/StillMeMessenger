using AutoMapper;
using StillMeBackend.MessengerAPI.DAL.Repositories;

namespace StillMeBackend.MessengerAPI.Services;

public abstract class ServiceBase<T, TDto> : IService<TDto> where T : class
{
    protected abstract IRepository<T> _repository { get;}
    protected readonly IMapper _mapper;

    public ServiceBase(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<ServiceResult<TDto>> AddAsync(TDto entity)
    {
        await _repository.AddAsync(_mapper.Map<T>(entity));
        await _repository.SaveAsync();

        return entity;
    }

    public IEnumerable<TDto> GetAll()
    {
        return _repository.GetAll().Select(c => _mapper.Map<TDto>(c));
    }

    public async Task<ServiceResult<TDto>> GetByIdAsync(object id)
    {
        var isValid = await ValidateId(id);
        if (!isValid)
            return "No records with such id";
        
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TDto>(entity);
    }
    
    public async Task<ServiceResult<TDto>> UpdateAsync(object id, TDto entity)
    {
        var isValid = await ValidateId(id);
        if (!isValid)
            return "No records with such id";
        
        await _repository.Update(id, _mapper.Map<T>(entity));
        await _repository.SaveAsync();

        return entity;
    }
    
    public async Task<ServiceResult<TDto>> DeleteAsync(object id)
    {
        var isValid = await ValidateId(id);
        if (!isValid)
            return "No records with such id";
        
        await _repository.DeleteAsync(id);
        await _repository.SaveAsync();

        return true;
    }

    private async Task<bool> ValidateId(object id)
    {
        return await _repository.IsExistingId(id);
    }
}