using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Sautom.Domain.Entities;
using Sautom.Services.Repositories;

namespace Sautom.DataAccess.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
	    protected RepositoryBase(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

	    protected DatabaseContext DatabaseContext { get; }

	    public virtual List<TEntity> FetchAll()
        {
            return DatabaseContext.Set<TEntity>().ToList();
        }

	    public virtual void Add(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Add(entity);
        }

	    public virtual void Delete(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Remove(entity);
        }

	    public virtual void Update(TEntity entity)
        {
            DbEntityEntry<TEntity> entry = DatabaseContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                DatabaseContext.Set<TEntity>().Attach(entity);
                entry.State = EntityState.Modified;
            }
        }

	    public virtual TEntity Get(Guid id)
        {
            return DatabaseContext.Set<TEntity>().Find(id);
        }

	    public ICollection<TEntity> GetMany(Guid[] ids)
        {
            return DatabaseContext.Set<TEntity>().Where(rec => ids.Contains(rec.Id)).ToList();
        }
    }
}
