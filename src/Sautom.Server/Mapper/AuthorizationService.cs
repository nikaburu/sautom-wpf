using AutoMapper;
using Sautom.Queries.ReadOptimizedDto;
using Sautom.Server.TransportDto;

namespace Sautom.Server.Mapper
{
    //todo T4
    public class AuthorizationService : Profile
	{
	    public AuthorizationService()
		{
			CreateMap<AunthorizationCredentialsDto, AunthorizationCredentialsDtoOutput>();
		}
	}
}
