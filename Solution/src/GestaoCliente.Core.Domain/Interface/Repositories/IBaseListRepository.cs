using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestaoCliente.Core.Domain.Interface.Repositories
{
    public interface IBaseListRepository<TEntity> where TEntity : class
    {
        TEntity? GetById(object? id);

        bool Exists(Expression<Func<TEntity, bool>> filter);

        ValueTask<TEntity?> GetByIdAsync(object? id);

        //IQueryable<TEntity> Get(bool isNoTracking = true, params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, bool isNoTracking);

        IQueryable<TEntity> Get(bool isNoTracking = true);

        //IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includeProperties);
    }
}