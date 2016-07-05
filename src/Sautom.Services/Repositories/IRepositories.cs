using Sautom.Domain.Entities;

namespace Sautom.Services.Repositories
{
			public partial interface IAuthorizationRepository : IRepository<Authorization>
		{}
		
			public interface ICityRepository : IRepository<City>
		{}
		
			public interface IClientRepository : IRepository<Client>
		{}
		
			public interface IAirlineTicketRepository : IRepository<AirlineTicket>
		{}
		
			public interface IContractRepository : IRepository<Contract>
		{}
		
			public interface IClientFileRepository : IRepository<ClientFile>
		{}
		
			public interface IRoleRepository : IRepository<Role>
		{}
		
			public interface IManagerCommentRepository : IRepository<ManagerComment>
		{}
		
			public interface IIntensityTypeRepository : IRepository<IntensityType>
		{}
		
			public interface ICountryRepository : IRepository<Country>
		{}
		
			public interface IEmbassyDocumentRepository : IRepository<EmbassyDocument>
		{}
		
			public interface IHousingTypeRepository : IRepository<HousingType>
		{}
		
			public partial interface IManagerRepository : IRepository<Manager>
		{}
		
			public interface IOrderRepository : IRepository<Order>
		{}
		
			public partial interface IProposalRepository : IRepository<Proposal>
		{}
		
			public interface IRateRepository : IRepository<Rate>
		{}
		
	}
