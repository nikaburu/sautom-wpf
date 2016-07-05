using System;

namespace Sautom.Services.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
	    void Commit();
    }
}