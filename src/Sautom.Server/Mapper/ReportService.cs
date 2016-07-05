using AutoMapper;
using Sautom.Queries.ReportOptimizedDto;
using Sautom.Server.TransportDto;

namespace Sautom.Server.Mapper
{
    //todo T4
    public class ReportService : Profile
	{
	    public ReportService()
		{
			CreateMap<OrderReportDto, OrderReportDtoReport>();
			CreateMap<OrderReportDtoReport, OrderReportDto>();
		}
	}
}
