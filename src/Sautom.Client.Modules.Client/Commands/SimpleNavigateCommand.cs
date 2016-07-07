using Prism.Regions;
using Sautom.Client.Comunication.Commands;

namespace Sautom.Client.Modules.Client.Commands
{
    public class SimpleNavigateCommand : CommandBase
    {
	    #region Constructors

	    public SimpleNavigateCommand(IRegionManager regionManager, string regionName, string clientIndex)
        {
            _regionName = regionName;
            _clientIndex = clientIndex;
            RegionManager = regionManager;
        }

	    #endregion

	    #region Properties

	    private IRegionManager RegionManager { get; }

	    #endregion

	    #region Overrides of CommandBase

	    protected override void Execute()
        {
            RegionManager.RequestNavigate(_regionName, _clientIndex);
        }

	    #endregion

	    #region Fields

	    private readonly string _regionName;
	    private readonly string _clientIndex;

	    #endregion
    }
}
