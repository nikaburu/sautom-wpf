using System;
using System.Collections.Generic;
using System.ServiceModel;
using Sautom.Queries;
using Sautom.Queries.ReadOptimizedDto;
using Sautom.Server.Interfaces;
using Sautom.Server.TransportDto;
using Sautom.Services.Dto;

namespace Sautom.Server.Services
{
    //todo T4
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    sealed public class FileService : IFileService
    {
	    #region Constructors

	    public FileService(IFileFinder fileFinder, Sautom.Services.FileService fileService, IClientFinder clientFinder)
        {
            FileFinder = fileFinder;
            FileServiceCommand = fileService;
            ClientFinder = clientFinder;
        }

	    #endregion

	    public IFileFinder FileFinder { get; set; }
	    public Sautom.Services.FileService FileServiceCommand { get; set; }
	    public IClientFinder ClientFinder { get; set; }

	    #region Properties

	    #endregion

	    #region Implementation of IFileService

	    public ICollection<GuidStringDtoOutput> ClientFileList(Guid clientId)
        {
            return AutoMapper.Mapper.Map<ICollection<GuidStringDtoOutput>>(FileFinder.ClientFileList(clientId));
        }

	    public FileDownloadDtoOutput ClientFile(Guid fileId)
        {
            FileDownloadDto file = FileFinder.ClientFile(fileId);
            return new FileDownloadDtoOutput
            {
                            Id  = file.Id,
                            FileExtension = file.FileExtension,
                            FileData = file.FileData,
                            FileName = file.FileName
                       };
        }

	    public bool UploadFile(ClientFileUploadDtoInput data)
        {
            //Mapper.Map<ClientFileUploadDto>(data);
            ClientFileUploadDto dataMapped = new ClientFileUploadDto
            {
                                     FileData = data.FileData,
                                     ClientId = data.ClientId,
                                     FileName = data.FileName,
                                     FileExtension = data.FileExtension
                                 };

            return FileServiceCommand.UploadFile(dataMapped).IsValid;
        }

	    public bool RemoveFile(Guid fileId)
        {
            return FileServiceCommand.RemoveFile(fileId).IsValid;
        }

	    public FileDownloadDtoOutput ClientContract(Guid clientId, string type)
        {
            return AutoMapper.Mapper.Map<FileDownloadDtoOutput>(ClientFinder.ClientContract(clientId, type));
        }

	    #endregion
    }
}
