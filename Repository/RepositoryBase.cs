﻿using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository;
public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{

    public RepositoryContext _context;

    public RepositoryBase(RepositoryContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges ?
            _context.Set<T>().AsNoTracking() 
            :
            _context.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges ?
            _context.Set<T>().Where(expression).AsNoTracking() 
            :
            _context.Set<T>().Where(expression);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }
}
