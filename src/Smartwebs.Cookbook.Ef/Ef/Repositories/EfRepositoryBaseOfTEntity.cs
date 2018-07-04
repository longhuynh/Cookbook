using Smartwebs.Domain.Entities;
using Smartwebs.Domain.Repositories;

namespace Smartwebs.Cookbook.Ef.Repositories
{
    public class EfRepositoryBase<TEntity> : EfRepositoryBaseOfTEntityAndTPrimaryKey<TEntity, int>,
        IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        public EfRepositoryBase(SmartwebsDbContext dbContext) : base(dbContext)
        {
        }
    }
}