﻿using GestaoCliente.Core.Domain.Interface;
using GestaoCliente.Core.Domain.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestaoCliente.Infra.Data.Repositories
{
    public class BaseListRepository<TEntity> : IBaseListRepository<TEntity> where TEntity : class
    {
        protected readonly DbGestaoCliente _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseListRepository(DbGestaoCliente dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual TEntity? GetById(object? id) => _dbSet.Find(id);

        public virtual ValueTask<TEntity?> GetByIdAsync(object? id) => _dbSet.FindAsync(id);

        public virtual IQueryable<TEntity> Get(bool isNoTracking = true, params Expression<Func<TEntity, object>>[] includeProperties) =>
           includeProperties
               .Aggregate(
                   (isNoTracking ? _dbSet.AsNoTracking() : _dbSet.AsTracking()),
                   (current, include) => current.Include(include));
    }
}