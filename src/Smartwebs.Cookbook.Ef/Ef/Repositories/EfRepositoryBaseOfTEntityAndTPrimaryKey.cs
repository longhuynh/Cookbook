using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Smartwebs.Domain.Entities;
using Smartwebs.Domain.Repositories;

namespace Smartwebs.Cookbook.Ef.Repositories
{
    /// <summary>
    ///     Implements IRepository for Entity Framework.
    /// </summary>
    /// <typeparam name="TEntity">Type of the Entity for this repository</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key of the entity</typeparam>
    public class EfRepositoryBaseOfTEntityAndTPrimaryKey<TEntity, TPrimaryKey> :
        RepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        ///     Gets EF DbContext object.
        /// </summary>
        private readonly SmartwebsDbContext _dbContext;

        public EfRepositoryBaseOfTEntityAndTPrimaryKey(SmartwebsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
     
        public override IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable(); 
        }

        public override TEntity Insert(TEntity entity)
        {
            return _dbContext.Set<TEntity>().Add(entity);
        }

        public override Task<TEntity> InsertAsync(TEntity entity)
        {
            return Task.FromResult(Insert(entity));
        }

        public override TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public override Task<TEntity> UpdateAsync(TEntity entity)
        {
            AttachIfNot(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            var entry = _dbContext.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            _dbContext.Set<TEntity>().Attach(entity);
        }
     
        public override Task SaveChangeAsync()
        {
            _dbContext.SaveChangesAsync();
            return Task.FromResult(0);
        }
    }
}