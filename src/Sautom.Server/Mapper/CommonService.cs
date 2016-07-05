using AutoMapper;
using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.Server.Mapper
{
    public class CommonService : Profile
	{
	    public CommonService()
		{
			CreateMap<EventNortification, EventNortification>();
		}
	}
} 