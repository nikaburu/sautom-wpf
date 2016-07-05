using System;
using System.Collections.Generic;
using System.ServiceModel;
using Sautom.Server.TransportDto;

namespace Sautom.Server.Interfaces
{
    [ServiceContract]
    public interface IFileService
    {
	    [OperationContract]
        ICollection<GuidStringDtoOutput> ClientFileList(Guid clientId);

	    [OperationContract]
        FileDownloadDtoOutput ClientFile(Guid fileId);

	    [OperationContract]
        bool UploadFile(ClientFileUploadDtoInput data);

	    [OperationContract]
        bool RemoveFile(Guid fileId);

	    [OperationContract]
        FileDownloadDtoOutput ClientContract(Guid clientId, string type);
    }
}
