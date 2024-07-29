﻿namespace StillMeBackend.MessengerAPI.DAL.Repositories;

public interface IRepository<T> : IDisposable where T : class
{
    IQueryable<T> GetAll();
    Task<T> GetByIdAsync(object id);
    Task AddAsync(T obj);
    Task Update(object id, T obj);
    Task DeleteAsync(object id);
    Task<bool> IsExistingId(object id);
    Task SaveAsync();
}