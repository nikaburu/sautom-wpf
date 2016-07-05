namespace Sautom.DataAccess.Queries
{
    public abstract class FinderBase
    {
	    protected FinderBase()
        {
            DatabaseContext = new DatabaseContext();
        }

	    public DatabaseContext DatabaseContext { get; private set; }
    }
}
