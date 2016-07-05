using System.Data;
using Sautom.Services.UnitOfWork;

namespace Sautom.DataAccess.UnitOfWorkAware
{
    public sealed class EfUnitOfWorkFactory : IUnitOfWorkFactory
    {
	    private readonly DatabaseContext _databaseContext;

	    public EfUnitOfWorkFactory(DatabaseContext context)
        {
            _databaseContext = context;
        }

	    #region IUnitOfWorkFactory Members

	    public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            return new EfUnitOfWork(_databaseContext);
        }

	    public IUnitOfWork Create()
        {
            return Create(IsolationLevel.ReadCommitted);
        }

	    #endregion
    }
}
