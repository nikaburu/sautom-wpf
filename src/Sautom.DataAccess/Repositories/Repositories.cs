
using Sautom.Domain.Entities;
using Sautom.Services.Repositories;

namespace Sautom.DataAccess.Repositories
{
		sealed public partial class AuthorizationRepository : RepositoryBase<Authorization>, IAuthorizationRepository
    {
			public AuthorizationRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public class CityRepository : RepositoryBase<City>, ICityRepository
    {
			public CityRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
			public ClientRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public class AirlineTicketRepository : RepositoryBase<AirlineTicket>, IAirlineTicketRepository
    {
			public AirlineTicketRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public class ContractRepository : RepositoryBase<Contract>, IContractRepository
    {
			public ContractRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public class ClientFileRepository : RepositoryBase<ClientFile>, IClientFileRepository
    {
			public ClientFileRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
			public RoleRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public class ManagerCommentRepository : RepositoryBase<ManagerComment>, IManagerCommentRepository
    {
			public ManagerCommentRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public class IntensityTypeRepository : RepositoryBase<IntensityType>, IIntensityTypeRepository
    {
			public IntensityTypeRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
			public CountryRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public class EmbassyDocumentRepository : RepositoryBase<EmbassyDocument>, IEmbassyDocumentRepository
    {
			public EmbassyDocumentRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public class HousingTypeRepository : RepositoryBase<HousingType>, IHousingTypeRepository
    {
			public HousingTypeRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public partial class ManagerRepository : RepositoryBase<Manager>, IManagerRepository
    {
			public ManagerRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
			public OrderRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public partial class ProposalRepository : RepositoryBase<Proposal>, IProposalRepository
    {
			public ProposalRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
		sealed public class RateRepository : RepositoryBase<Rate>, IRateRepository
    {
			public RateRepository(DatabaseContext databaseContext)
            : base(databaseContext)
        {
        }
    }
		
	}
