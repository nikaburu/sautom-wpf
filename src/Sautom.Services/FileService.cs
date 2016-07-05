using System;
using System.Collections.Generic;
using Sautom.Domain.Entities;
using Sautom.Services.Dto;
using Sautom.Services.Repositories;
using Sautom.Services.UnitOfWork;

namespace Sautom.Services
{
    public sealed class FileService
    {
	    #region Constructors

	    public FileService(IUnitOfWorkFactory unitOfWorkFactory, IClientFileRepository fileRepository, IClientRepository clientRepository)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
            FileRepository = fileRepository;
            ClientRepository = clientRepository;
        }

	    #endregion

	    public ICommandState UploadFile(ClientFileUploadDto data)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                //Mapper.CreateMap<ClientFileUploadDto, ClientFile>();
                //var file = Mapper.Map<ClientFile>(data);
                ClientFile file = new ClientFile
                               {
                                   FileData = data.FileData,
                                   FileName = data.FileName,
                                   Client = ClientRepository.Get(data.ClientId),
                                   FileExtension = data.FileExtension
                               };


                FileRepository.Add(file);

                uow.Commit();
            }
            
            return new DefaultCommandState { IsValid = true };
        }

	    public ICommandState RemoveFile(Guid fileId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                ClientFile file = FileRepository.Get(fileId);

                if (file != null)
                {
                    FileRepository.Delete(file);

                    uow.Commit();

                    return new DefaultCommandState { IsValid = true };
                }

                return new DefaultCommandState { IsValid = false, State = new Dictionary<string, object> { { "file", "File not found!" } } };
            }
        }

	    #region Properties

	    public IUnitOfWorkFactory UnitOfWorkFactory { get; }
	    public IClientFileRepository FileRepository { get; set; }
	    public IClientRepository ClientRepository { get; set; }

	    #endregion
    }
}
