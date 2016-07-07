using System.Windows.Controls;

namespace Sautom.Client.Ui.Controls
{
    public interface IModalDialogPopup
    {
	    #region Properties

	    /// <summary>
        /// Gets or sets the content to host
        /// </summary>
        Control HostedContent
        {
            get;
            set;
        }

	    /// <summary>
        /// Shows the dialog
        /// </summary>
        bool IsOpen
        {
            get; set; }

	    #endregion Properties
    }

}