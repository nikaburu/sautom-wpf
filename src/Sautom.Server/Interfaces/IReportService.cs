using System.Collections.Generic;
using System.ServiceModel;
using Sautom.Server.TransportDto;

namespace Sautom.Server.Interfaces
{
    [ServiceContract]
    public interface IReportService
    {
	    [OperationContract]
        List<OrderReportDtoReport> OrderReport(OrderReportDtoReport standard);
    }
}
