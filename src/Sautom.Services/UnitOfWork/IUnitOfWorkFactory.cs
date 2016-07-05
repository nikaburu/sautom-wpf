namespace Sautom.Services.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
	    IUnitOfWork Create();
    }
}