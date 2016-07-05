using AutoMapper;
using Sautom.Queries.ReadOptimizedDto;
using Sautom.Server.TransportDto;
using Sautom.Services.Dto;

namespace Sautom.Server.Mapper
{
    //todo T4
    public class FileService : Profile
	{
	    public FileService()
		{
			CreateMap<GuidStringDto, GuidStringDtoOutput>();
			CreateMap<FileDownloadDto, FileDownloadDtoOutput>();
			CreateMap<ClientFileUploadDtoInput, ClientFileUploadDto>();
		}
	}
}
