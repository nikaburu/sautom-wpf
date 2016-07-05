


using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sautom.Server.TransportDto //23
{
    
    [DataContract]
    public class AunthorizationCredentialsDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string UserName
			{
				get; set;
			}

	    [DataMember]
			public string UserDisplayName
			{
				get; set;
			}

	    [DataMember]    
        public IList<string> Roles
        {   
            get;
            internal set;
        }
    }
        
    [DataContract]
    public class ClientEditDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string PersonalNumber
			{
				get; set;
			}

	    [DataMember]
			public string NameLat
			{
				get; set;
			}

	    [DataMember]
			public string FirstName
			{
				get; set;
			}

	    [DataMember]
			public string LastName
			{
				get; set;
			}

	    [DataMember]
			public string MiddleName
			{
				get; set;
			}

	    [DataMember]
			public DateTime? BirthDate
			{
				get; set;
			}

	    [DataMember]
			public string PassportInfo
			{
				get; set;
			}

	    [DataMember]
			public string PassportByWhom
			{
				get; set;
			}

	    [DataMember]
			public DateTime? PassportFromDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime? PassportByDate
			{
				get; set;
			}

	    [DataMember]
			public string Address
			{
				get; set;
			}

	    [DataMember]
			public string PhoneFirst
			{
				get; set;
			}

	    [DataMember]
			public string PhoneSecond
			{
				get; set;
			}

	    [DataMember]
			public string ParentName
			{
				get; set;
			}

	    [DataMember]
			public string ParentAddress
			{
				get; set;
			}

	    [DataMember]
			public string ParentPhone
			{
				get; set;
			}

	    [DataMember]
			public string ParentPassportInfo
			{
				get; set;
			}
    }
        
    [DataContract]
    public class ClientItemDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string PersonalNumber
			{
				get; set;
			}

	    [DataMember]
			public string NameLat
			{
				get; set;
			}

	    [DataMember]
			public string NameRu
			{
				get; set;
			}

	    [DataMember]
			public bool IsActiveClient
			{
				get; set;
			}

	    [DataMember]
			public string SchoolName
			{
				get; set;
			}

	    [DataMember]
			public string CourseName
			{
				get; set;
			}

	    [DataMember]
			public DateTime StartDate
			{
				get; set;
			}

	    [DataMember]
			public int OrdersCount
			{
				get; set;
			}

	    [DataMember]
			public bool IsHot
			{
				get; set;
			}
    }
        
    [DataContract]
    public class ClientViewDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string PersonalNumber
			{
				get; set;
			}

	    [DataMember]
			public string NameLat
			{
				get; set;
			}

	    [DataMember]
			public string FirstName
			{
				get; set;
			}

	    [DataMember]
			public string LastName
			{
				get; set;
			}

	    [DataMember]
			public string MiddleName
			{
				get; set;
			}

	    [DataMember]
			public DateTime? BirthDate
			{
				get; set;
			}

	    [DataMember]
			public string PassportInfo
			{
				get; set;
			}

	    [DataMember]
			public string PassportByWhom
			{
				get; set;
			}

	    [DataMember]
			public DateTime? PassportFromDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime? PassportByDate
			{
				get; set;
			}

	    [DataMember]
			public string Address
			{
				get; set;
			}

	    [DataMember]
			public string PhoneFirst
			{
				get; set;
			}

	    [DataMember]
			public string PhoneSecond
			{
				get; set;
			}

	    [DataMember]    
        public IList<OrderItemDtoOutput> Orders
        {   
            get;
            internal set;
        }

	    [DataMember]    
        public IList<ManagerCommentItemDtoOutput> Comments
        {   
            get;
            internal set;
        }

	    [DataMember]
			public string ParentName
			{
				get; set;
			}

	    [DataMember]
			public string ParentAddress
			{
				get; set;
			}

	    [DataMember]
			public string ParentPhone
			{
				get; set;
			}

	    [DataMember]
			public string ParentPassportInfo
			{
				get; set;
			}
    }
        
    [DataContract]
    public class CityItemDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string CityName
			{
				get; set;
			}
    }
        
    [DataContract]
    public class AirlineTicketEditDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string DepartureCity
			{
				get; set;
			}

	    [DataMember]
			public DateTime? DepartureDate
			{
				get; set;
			}

	    [DataMember]
			public string ArrivalCity
			{
				get; set;
			}

	    [DataMember]
			public DateTime? ArrivalDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime? BookingDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime? BookingExpireDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime? RedemptionDate
			{
				get; set;
			}

	    [DataMember]
			public Guid OrderId
			{
				get; set;
			}
    }
        
    [DataContract]
    public class AirlineTicketViewDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string DepartureCity
			{
				get; set;
			}

	    [DataMember]
			public DateTime? DepartureDate
			{
				get; set;
			}

	    [DataMember]
			public string ArrivalCity
			{
				get; set;
			}

	    [DataMember]
			public DateTime? ArrivalDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime? BookingDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime? BookingExpireDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime? RedemptionDate
			{
				get; set;
			}
    }
        
    [DataContract]
    public class ContractViewDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string ConsultingNumber
			{
				get; set;
			}

	    [DataMember]
			public DateTime? ConsultingDate
			{
				get; set;
			}

	    [DataMember]
			public float ConsultingHours
			{
				get; set;
			}

	    [DataMember]
			public int ConsultingSum
			{
				get; set;
			}

	    [DataMember]
			public DateTime? ConsultingActDate
			{
				get; set;
			}

	    [DataMember]
			public string WorkshopNumber
			{
				get; set;
			}

	    [DataMember]
			public DateTime? WorkshopDate
			{
				get; set;
			}

	    [DataMember]
			public float WorkshopHours
			{
				get; set;
			}

	    [DataMember]
			public int WorkshopSum
			{
				get; set;
			}

	    [DataMember]
			public DateTime? WorkshopActDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime? InvoiceDate
			{
				get; set;
			}

	    [DataMember]
			public int InvoiceSum
			{
				get; set;
			}
    }
        
    [DataContract]
    public class ContractEditDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string ConsultingNumber
			{
				get; set;
			}

	    [DataMember]
			public DateTime? ConsultingDate
			{
				get; set;
			}

	    [DataMember]
			public float ConsultingHours
			{
				get; set;
			}

	    [DataMember]
			public DateTime? ConsultingActDate
			{
				get; set;
			}

	    [DataMember]
			public string WorkshopNumber
			{
				get; set;
			}

	    [DataMember]
			public DateTime? WorkshopDate
			{
				get; set;
			}

	    [DataMember]
			public float WorkshopHours
			{
				get; set;
			}

	    [DataMember]
			public DateTime? WorkshopActDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime? InvoiceDate
			{
				get; set;
			}

	    [DataMember]
			public int InvoiceSum
			{
				get; set;
			}

	    [DataMember]    
        public IList<RateItemDtoOutput> Rates
        {   
            get;
            internal set;
        }
    }
        
    [DataContract]
    public class ManagerCommentItemDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string Manager
			{
				get; set;
			}

	    [DataMember]
			public DateTime Date
			{
				get; set;
			}

	    [DataMember]
			public string Comment
			{
				get; set;
			}
    }
        
    [DataContract]
    public class EventNortificationOutput     
    {
	    [DataMember]
			public string EventName
			{
				get; set;
			}

	    [DataMember]    
        public Dictionary<string, object> Args
        {   
            get;
            internal set;
        }
    }
        
    [DataContract]
    public class FileDownloadDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string FileName
			{
				get; set;
			}

	    [DataMember]
			public string FileExtension
			{
				get; set;
			}

	    [DataMember]
			public byte[] FileData
			{
				get; set;
			}
    }
        
    [DataContract]
    public class RateItemDtoOutput     
    {
	    [DataMember]
			public DateTime Date
			{
				get; set;
			}

	    [DataMember]
			public float RateValue
			{
				get; set;
			}
    }
        
    [DataContract]
    public class CountryWitCitiesDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string CountryName
			{
				get; set;
			}

	    [DataMember]    
        public IList<CityItemDtoOutput> Cities
        {   
            get;
            internal set;
        }
    }
        
    [DataContract]
    public class CountryEditDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string CountryName
			{
				get; set;
			}

	    [DataMember]    
        public IList<CityItemDtoOutput> Cities
        {   
            get;
            internal set;
        }

	    [DataMember]    
        public IList<EmbassyDocumentItemDtoOutput> EmbassyDocuments
        {   
            get;
            internal set;
        }
    }
        
    [DataContract]
    public class CountryItemDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string CountryName
			{
				get; set;
			}
    }
        
    [DataContract]
    public class CreateOrderInfoDtoOutput     
    {
	    [DataMember]    
        public IList<ProposalDtoOutput> Proposals
        {   
            get;
            internal set;
        }

	    [DataMember]    
        public IList<ManagerDtoOutput> ResponsibleManagers
        {   
            get;
            internal set;
        }
    }
        
    [DataContract]
    public class GuidStringDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string Element
			{
				get; set;
			}
    }
        
    [DataContract]
    public class EmbassyDocumentItemDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string DocumentName
			{
				get; set;
			}

	    [DataMember]
			public bool IsArchival
			{
				get; set;
			}
    }
        
    [DataContract]
    public class ManagerDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string DisplayName
			{
				get; set;
			}
    }
        
    [DataContract]
    public class OrderItemDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string SchoolName
			{
				get; set;
			}

	    [DataMember]
			public string CourseName
			{
				get; set;
			}

	    [DataMember]
			public bool IsGroupType
			{
				get; set;
			}

	    [DataMember]
			public string ResponsibleManager
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

	    [DataMember]
			public string Intensity
			{
				get; set;
			}

	    [DataMember]
			public string HouseType
			{
				get; set;
			}

	    [DataMember]
			public bool IsActive
			{
				get; set;
			}

	    [DataMember]
			public DateTime? EmbassyDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime? VisaDate
			{
				get; set;
			}

	    [DataMember]
			public bool IsEmbassyChecked
			{
				get; set;
			}

	    [DataMember]    
        public IList<Guid> Docs
        {   
            get;
            internal set;
        }

	    [DataMember]    
        public IList<GuidStringDtoOutput> FullDocsList
        {   
            get;
            internal set;
        }

	    [DataMember]
        public AirlineTicketViewDtoOutput AirlineTicket
        {
            get; set;
        }
    }
        
    [DataContract]
    public class ProposalDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public string Country
			{
				get; set;
			}

	    [DataMember]
			public string City
			{
				get; set;
			}

	    [DataMember]
			public string SchoolName
			{
				get; set;
			}

	    [DataMember]
			public string CourseName
			{
				get; set;
			}

	    [DataMember]    
        public IList<GuidStringDtoOutput> Intensities
        {   
            get;
            internal set;
        }

	    [DataMember]    
        public IList<GuidStringDtoOutput> HouseTypes
        {   
            get;
            internal set;
        }

	    [DataMember]
			public bool IsGroupType
			{
				get; set;
			}

	    [DataMember]
			public DateTime? StartDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime? EndDate
			{
				get; set;
			}

	    [DataMember]
			public string CuratorName
			{
				get; set;
			}
    }
        
    [DataContract]
    public class ProposalEditDtoOutput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public Guid CityId
			{
				get; set;
			}

	    [DataMember]
			public Guid CountryId
			{
				get; set;
			}

	    [DataMember]
			public string SchoolName
			{
				get; set;
			}

	    [DataMember]
			public string CourseName
			{
				get; set;
			}

	    [DataMember]    
        public IList<GuidStringDtoOutput> AvailableIntensities
        {   
            get;
            internal set;
        }

	    [DataMember]    
        public IList<Guid> Intensities
        {   
            get;
            internal set;
        }

	    [DataMember]    
        public IList<GuidStringDtoOutput> AvailableHouseTypes
        {   
            get;
            internal set;
        }

	    [DataMember]    
        public IList<Guid> HouseTypes
        {   
            get;
            internal set;
        }

	    [DataMember]
			public bool IsGroupType
			{
				get; set;
			}

	    [DataMember]
			public string CuratorName
			{
				get; set;
			}

	    [DataMember]
			public DateTime? StartDate
			{
				get; set;
			}

	    [DataMember]
			public DateTime? EndDate
			{
				get; set;
			}
    }
        
}
