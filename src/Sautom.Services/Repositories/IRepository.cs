using System;
using System.Collections.Generic;
using Sautom.Domain.Entities;

namespace Sautom.Services.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
	    List<TEntity> FetchAll();

	    void Add(TEntity entity);
	    void Delete(TEntity entity);
	    void Update(TEntity proposal);

	    TEntity Get(Guid id);
	    ICollection<TEntity> GetMany(Guid[] ids);
    }
}
