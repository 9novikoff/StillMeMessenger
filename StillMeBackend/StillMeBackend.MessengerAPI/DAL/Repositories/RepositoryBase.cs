﻿using Microsoft.EntityFrameworkCore;

namespace StillMeBackend.MessengerAPI.DAL.Repositories;

public abstract class RepositoryBase<T> : IRepository<T> where T : class
{
    protected readonly DbContext _context;
    private readonly DbSet<T> _table;
    private bool _disposed = false;
    
    protected RepositoryBase(DbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }
    
    public IQueryable<T> GetAll()
    {
        return _table.Select(x => x);
    }
    
    public async Task<T> GetByIdAsync(object id)
    {
        return await _table.FindAsync(id);
    }
    
    public async Task AddAsync(T obj)
    {
        await _table.AddAsync(obj);
    }
    
    public async Task Update(object id, T obj)
    {
        var current = await _table.FindAsync(id);
        foreach (var propertyEntry in _context.Entry(current).Properties)
        {
            var property = propertyEntry.Metadata;
            if (property.IsShadowProperty() || (propertyEntry.EntityEntry.IsKeySet && property.IsKey())) continue;
            propertyEntry.CurrentValue = property.GetGetter().GetClrValue(obj);
        }
    }
    
    public async Task DeleteAsync(object id)
    {
        T current = await _table.FindAsync(id);
        _table.Remove(current);
    }

    public async Task<bool> IsExistingId(object id)
    {
        var current = await _table.FindAsync(id);
        return current != null;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}