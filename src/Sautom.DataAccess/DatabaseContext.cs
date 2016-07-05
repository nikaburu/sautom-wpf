using System.Data.Entity;
using Sautom.DataAccess.TypeConfiguration;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess
{
    public sealed class DatabaseContext : DbContext
    {
	    public DatabaseContext()
        {
            Database.SetInitializer(new EntitiesContextInitializer());
        }

	    public DbSet<Client> Clients { get; set; }
	    public DbSet<Manager> Managers { get; set; }
	    public DbSet<Proposal> Proposals { get; set; }
	    public DbSet<Order> Orders { get; set; }
	    public DbSet<EmbassyDocument> EmbassyDocuments { get; set; }
	    public DbSet<Country> Countries { get; set; }
	    public DbSet<City> Cities { get; set; }
	    public DbSet<AirlineTicket> AirlineTickets { get; set; }
	    public DbSet<Contract> Contracts { get; set; }
	    public DbSet<ClientFile> Files { get; set; }
	    public DbSet<Authorization> Authorizations { get; set; }

	    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new ManagerConfiguration());
            modelBuilder.Configurations.Add(new ProposalConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new EmbassyDocumentConfiguration());
            modelBuilder.Configurations.Add(new HousingTypeConfiguration());
            modelBuilder.Configurations.Add(new IntensityTypeConfiguration()); 
            modelBuilder.Configurations.Add(new RateConfiguration());
            modelBuilder.Configurations.Add(new AirlineTicketConfiguration());
            modelBuilder.Configurations.Add(new ContractConfiguration());
            modelBuilder.Configurations.Add(new ClientFileConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new AuthorizationConfiguration());

            modelBuilder.ComplexType<ClientParent>();
        }
    }
}
