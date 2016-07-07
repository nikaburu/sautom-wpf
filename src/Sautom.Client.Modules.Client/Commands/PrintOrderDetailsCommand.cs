using System;
using Sautom.Client.Comunication;
using Sautom.Client.Comunication.Commands;
using Sautom.Client.Comunication.FileService;

namespace Sautom.Client.Modules.Client.Commands
{
    public class PrintOrderDetailsCommand : CommandBase<Guid>
    {
	    #region Constructors

	    public PrintOrderDetailsCommand(ClientFileHelper clientFileHelper, IFileService fileServiceClient)
        {
            ClientFileHelper = clientFileHelper;
            FileServiceClient = fileServiceClient;
        }

	    #endregion

	    #region Overrides of CommandBase

	    protected override void Execute(Guid orderId)
        {
            //todo find good name for the template rendener
            FileDownloadDtoOutput fileData = FileServiceClient.ClientContract(orderId, "OrderDetails");

            if (fileData != null && fileData.FileData.Length != 0)
            {
                ClientFileHelper.PrintDocxFile(fileData.FileData);
            }
        }

	    #endregion

	    #region Properties

	    private ClientFileHelper ClientFileHelper { get; }
	    private IFileService FileServiceClient { get; }

	    #endregion
    }
}
