using GestaoCliente.Core.Domain.Interface;
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

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter) => Get(filter).Any();

        public virtual ValueTask<TEntity?> GetByIdAsync(object? id) => _dbSet.FindAsync(id);

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter) => Get().Where(filter);

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, bool isNoTracking) => Get(isNoTracking).Where(filter);

        public IQueryable<TEntity> Get(bool isNoTracking = true) => (isNoTracking ? _dbSet.AsNoTracking() : _dbSet.AsNoTracking());

        //public IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includeProperties) => Get(false, includeProperties);

        //public virtual IQueryable<TEntity> Get(bool isNoTracking = true, params Expression<Func<TEntity, object>>[] includeProperties) =>
        //   includeProperties
        //       .Aggregate(
        //           ,
        //           (current, include) => current.Include(include));
    }
}