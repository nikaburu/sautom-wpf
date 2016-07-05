


using System;
using System.Runtime.Serialization;

namespace Sautom.Server.TransportDto //1
{
    
    [DataContract]
    public class OrderReportDtoReport     
    {
	    [DataMember]
			public string ClientName
			{
				get; set;
			}

	    [DataMember]
			public string SchoolName
			{
				get; set;
			}

	    [DataMember]
			public string CourceName
			{
				get; set;
			}

	    [DataMember]
			public DateTime StartDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime EndDate
			{
				get; set;
			}
    }
        
}
