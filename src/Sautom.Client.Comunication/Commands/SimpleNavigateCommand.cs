using Prism.Regions;

namespace Sautom.Client.Comunication.Commands
{
    public class SimpleNavigateCommand : CommandBase
    {
        #region Fields
        private readonly string _regionName;
        private readonly string _clientIndex;

        #endregion

        #region Properties
        private IRegionManager RegionManager { get; set; }
        #endregion

        #region Constructors
        public SimpleNavigateCommand(IRegionManager regionManager, string regionName, string clientIndex)
        {
            _regionName = regionName;
            _clientIndex = clientIndex;
            RegionManager = regionManager;
        }

        #endregion

        #region Overrides of CommandBase

	    protected override void Execute()
        {
            RegionManager.RequestNavigate(_regionName, _clientIndex);
        }

        #endregion
    }
}
