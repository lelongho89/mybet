using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace FunBet.EntityFramework.Repositories
{
    public abstract class FunBetRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<FunBetDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected FunBetRepositoryBase(IDbContextProvider<FunBetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class FunBetRepositoryBase<TEntity> : FunBetRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected FunBetRepositoryBase(IDbContextProvider<FunBetDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
