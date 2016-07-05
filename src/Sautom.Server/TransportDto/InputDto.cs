


using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sautom.Server.TransportDto //10
{
    
    [DataContract]
    public class ClientFileUploadDtoInput     
    {
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

	    [DataMember]
			public Guid ClientId
			{
				get; set;
			}
    }
        
    [DataContract]
    public class AirlineTicketEditDtoInput     
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
    public class CityItemDtoInput     
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
    public class ClientEditDtoInput     
    {
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

	    [DataMember]
        public OrderEditDtoInput OrderInfo
        {
            get; set;
        }
    }
        
    [DataContract]
    public class ContractEditDtoInput     
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
			public float ConsultingSum
			{
				get; set;
			}

	    [DataMember]
			public DateTime? ConsultingActDate
			{
				get; set;
			}

	    [DataMember]
        public RateItemDtoInput ConsultingRate
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
			public float WorkshopSum
			{
				get; set;
			}

	    [DataMember]
			public DateTime? WorkshopActDate
			{
				get; set;
			}

	    [DataMember]
        public RateItemDtoInput WorkshopRate
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
			public Guid OrderId
			{
				get; set;
			}
    }
        
    [DataContract]
    public class OrderEditDtoInput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

	    [DataMember]
			public Guid ProposalId
			{
				get; set;
			}

	    [DataMember]
			public Guid ManagerId
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
			public Guid IntensityId
			{
				get; set;
			}

	    [DataMember]
			public Guid HouseTypeId
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
			public bool? IsEmbassyChecked
			{
				get; set;
			}

	    [DataMember]    
        public IList<Guid> EmbassyDocs
        {   
            get;
            internal set;
        }
    }
        
    [DataContract]
    public class CounrtyEditDtoInput     
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
        public IList<CityItemDtoInput> Cities
        {   
            get;
            internal set;
        }

	    [DataMember]    
        public IList<EmbassyDocumentItemDtoInput> EmbassyDocuments
        {   
            get;
            internal set;
        }
    }
        
    [DataContract]
    public class EmbassyDocumentItemDtoInput     
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
    public class RateItemDtoInput     
    {
	    [DataMember]
			public Guid Id
			{
				get; set;
			}

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
    public class ProposalEditDtoInput     
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
        public IList<Guid> Intensities
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
