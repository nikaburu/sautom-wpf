using System;
using Prism.Events;
using Sautom.Client.Comunication.FileService;
using FileDownloadDtoOutput = Sautom.Client.Comunication.FileService.FileDownloadDtoOutput;
using GuidStringDtoOutput = Sautom.Client.Comunication.FileService.GuidStringDtoOutput;

namespace Sautom.Client.Comunication.Services
{
    internal class FilesServiceAdapter : BaseServiceAdapter, IFileService
    {
        #region Properties
        private FileServiceClient ServiceClient { get; set; }
        #endregion

        #region Constructors
        public FilesServiceAdapter(FileServiceClient client, IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            ServiceClient = client;
        }
        #endregion

        #region Implementation of IFileService

        public GuidStringDtoOutput[] ClientFileList(Guid clientId)
        {
            return ExceptionAware(() => ServiceClient.ClientFileList(clientId), () => new GuidStringDtoOutput[0]);
        }

        public FileDownloadDtoOutput ClientFile(Guid fileId)
        {
            return ExceptionAware(() => ServiceClient.ClientFile(fileId));
        }

        public bool UploadFile(ClientFileUploadDtoInput data)
        {
            return ExceptionAware(() => new BoolWrapper(ServiceClient.UploadFile(data))).Value;
        }

        public bool RemoveFile(Guid fileId)
        {
            return ExceptionAware(() => new BoolWrapper(ServiceClient.RemoveFile(fileId))).Value;
        }
        
        public FileDownloadDtoOutput ClientContract(Guid clientId, string type)
        {
            return ExceptionAware(() => ServiceClient.ClientContract(clientId, type));
        }

        #endregion
    }
}
