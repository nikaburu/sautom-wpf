using System;
using Sautom.Services.UnitOfWork;

namespace Sautom.DataAccess.UnitOfWorkAware
{
    internal sealed class EfUnitOfWork : IUnitOfWork
    {
	    private readonly DatabaseContext _context;

	    public EfUnitOfWork(DatabaseContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

	    #region IUnitOfWork Members

	    public void Commit()
        {
	        _context?.SaveChanges();
        }

	    #endregion

	    #region IDispassable

	    private bool _disposed;

	    private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
	            _context?.Dispose();
            }

	        _disposed = true;
        }

	    public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

	    #endregion
    }
}
