using Smartwebs.Domain.Entities;
using Smartwebs.Domain.Repositories;

namespace Smartwebs.Cookbook.Ef.Repositories
{
    public class EfRepositoryBase<TEntity> : EfRepositoryBase<TEntity, int>,
        IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        public EfRepositoryBase(CookbookDbContext dbContext) : base(dbContext)
        {
        }
    }
}