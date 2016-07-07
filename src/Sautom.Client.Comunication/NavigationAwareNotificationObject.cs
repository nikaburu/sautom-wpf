using Prism.Mvvm;
using Prism.Regions;

namespace Sautom.Client.Comunication
{
    public abstract class NavigationAwareNotificationObject : BindableBase, INavigationAware
    {
        #region Implementation of INavigationAware

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        #endregion
    }
}
