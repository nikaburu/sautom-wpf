using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using LinqKit;
using Sautom.DataAccess.Helpers.Templates;
using Sautom.Domain.Entities;
using Sautom.Queries;
using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.DataAccess.Queries
{
    public sealed class ClientFinder : FinderBase, IClientFinder
    {
	    #region Constructors

	    public ClientFinder(IMapper mapper)
	    {
	        Mapper = mapper;
        }

	    #endregion

	    #region Dependencies

	    private IMapper Mapper { get; }

	    #endregion

	    public ICollection<ClientItemDto> GetAllClients(string personalNumberFilter, string nameRuFilter, string courseNameFilter)
        {
            //Mapper.CreateMap<Client, ClientItemDto>()
            //    .ForMember(foo => foo.OrdersCount, foo => foo.MapFrom(bar => bar.Orders.Count))
            //    .ForMember(foo => foo.IsActiveClient, foo => foo.MapFrom(bar => bar.Orders.Any(ord => ord.IsActive)))
            //    .ForMember(foo => foo.SchoolName,
            //               foo =>
            //               foo.MapFrom(
            //                   bar =>
            //                   bar.Orders.Any(ord => ord.IsActive)
            //                       ? bar.Orders.First(ord => ord.IsActive).Proposal.SchoolName
            //                       : String.Empty))
            //    .ForMember(foo => foo.CourseName,
            //               foo =>
            //               foo.MapFrom(
            //                   bar =>
            //                   bar.Orders.Any(ord => ord.IsActive)
            //                       ? bar.Orders.First(ord => ord.IsActive).Proposal.CourseName
            //                       : String.Empty))
            //    .ForMember(foo => foo.StartDate,
            //               foo =>
            //               foo.MapFrom(
            //                   bar =>
            //                   bar.Orders.Any(ord => ord.IsActive)
            //                       ? bar.Orders.First(ord => ord.IsActive).StartDate
            //                       : default(DateTime)))
            //    .ForMember(foo => foo.NameRu,
            //               foo => foo.ResolveUsing(bar => bar.LastName + " " + bar.FirstName + " " + bar.MiddleName));

            //todo make generic!

            Expression<Func<ClientItemDto, bool>> where = PredicateBuilder.True<ClientItemDto>();

            if (!string.IsNullOrWhiteSpace(personalNumberFilter))
            {
                where = where.And(rec => rec.PersonalNumber.Contains(personalNumberFilter));
            }

            if (!string.IsNullOrWhiteSpace(nameRuFilter))
            {
                where = where.And(rec => rec.NameRu.Contains(nameRuFilter));
            }

            if (!string.IsNullOrWhiteSpace(courseNameFilter))
            {
                where = where.And(rec => rec.CourseName.Contains(courseNameFilter));
            }

            List<ClientItemDto> clients = DatabaseContext.Clients.Select(rec => new ClientItemDto
            {
                                                                        Id = rec.Id,
                                                                        CourseName = rec.Orders.Any(ord => ord.StartDate > DateTime.Now) ? rec.Orders.FirstOrDefault(ord => ord.StartDate > DateTime.Now).Proposal.CourseName : string.Empty,
                                                                        StartDate = rec.Orders.Any(ord => ord.StartDate > DateTime.Now) ? rec.Orders.FirstOrDefault(ord => ord.StartDate > DateTime.Now).StartDate : default(DateTime),
                                                                        NameRu = rec.LastName + " " + rec.FirstName + " " + rec.MiddleName,
                                                                        SchoolName = rec.Orders.Any(ord => ord.StartDate > DateTime.Now) ? rec.Orders.FirstOrDefault(ord => ord.StartDate > DateTime.Now).Proposal.SchoolName : string.Empty,
                                                                        IsActiveClient = rec.Orders.Any(ord => ord.StartDate > DateTime.Now),
                                                                        OrdersCount = rec.Orders.Count,
                                                                        NameLat = rec.NameLat,
                                                                        PersonalNumber = rec.PersonalNumber
                                                                    }).AsExpandable().Where(where).ToList();

            List<ClientItemDto> clientDtos = clients;//Mapper.Map<ICollection<ClientItemDto>>(clients);

            return clientDtos;
        }

	    public ClientEditDto GetClientForEdit(Guid clientId)
        {
            Client client = DatabaseContext.Clients.FirstOrDefault(rec => rec.Id == clientId);
            return Mapper.Map<ClientEditDto>(client);
        }

	    public ClientViewDto GetClientForView(Guid clientId)
        {
            Client client = DatabaseContext.Clients.FirstOrDefault(rec => rec.Id == clientId);

            ClientViewDto dto = Mapper.Map<ClientViewDto>(client);
            foreach (OrderItemDto order in dto.Orders)
            {
                Order clientOrder = client.Orders.First(rec => rec.Id == order.Id);

                order.FullDocsList = DatabaseContext.EmbassyDocuments
                    .Where(rec => rec.Country.Id == clientOrder.Proposal.City.Country.Id && !rec.IsArchival)
                    .Select(rec => new GuidStringDto { Id = rec.Id, Element = rec.DocumentName }).ToList();

                AirlineTicket airTicket = DatabaseContext.AirlineTickets.FirstOrDefault(rec => rec.Order.Id == clientOrder.Id);
                order.AirlineTicket = Mapper.Map<AirlineTicketViewDto>(airTicket);
            }

            return dto;
        }

	    public CreateOrderInfoDto GetOrderCreationData()
        {
            List<Proposal> proposals =
                DatabaseContext.Proposals.ToList();

            CreateOrderInfoDto model = new CreateOrderInfoDto
            {
                           Proposals = Mapper.Map<List<ProposalDto>>(proposals),
                           ResponsibleManagers = Mapper.Map<List<ManagerDto>>(DatabaseContext.Managers.ToList())
                       };

            return model;
        }

	    public CreateOrderInfoDto GetOrderEditData(Guid orderId)
        {
            Proposal proposal = DatabaseContext.Orders.Find(orderId).Proposal;

            CreateOrderInfoDto model = new CreateOrderInfoDto
            {
                Proposals = new List<ProposalDto> { Mapper.Map<ProposalDto>(proposal) },
                ResponsibleManagers = Mapper.Map<List<ManagerDto>>(DatabaseContext.Managers.ToList())
            };

            return model;
        }

	    public AirlineTicketViewDto AirlineTicketForView(Guid orderId)
        {
            AirlineTicket ticket = DatabaseContext.AirlineTickets.FirstOrDefault(rec => rec.Order.Id == orderId);
            AirlineTicketViewDto mapped = Mapper.Map<AirlineTicketViewDto>(ticket);

            return mapped;
        }

	    public AirlineTicketEditDto AirlineTicketForEdit(Guid airlineTickedId)
        {
			AirlineTicket ticket = DatabaseContext.AirlineTickets.FirstOrDefault(rec => rec.Id == airlineTickedId);
            AirlineTicketEditDto mapped = Mapper.Map<AirlineTicketEditDto>(ticket);

            return mapped;
        }

	    public ContractViewDto ContractForView(Guid orderId)
        {
			Contract contract = DatabaseContext.Contracts.FirstOrDefault(rec => rec.Order.Id == orderId);
            ContractViewDto mapped = Mapper.Map<ContractViewDto>(contract);

            return mapped;
        }

	    public ContractEditDto ContractForEdit(Guid contractId)
        {
			Contract contract = DatabaseContext.Contracts.FirstOrDefault(rec => rec.Id == contractId);
            ContractEditDto mapped = Mapper.Map<ContractEditDto>(contract) ?? new ContractEditDto();

            mapped.Rates = DatabaseContext.Set<Rate>().Select(rec => new RateItemDto
            {
                Date = rec.Date,
                RateValue = rec.RateValue
            }).ToList();

            return mapped;
        }

	    public FileDownloadDto ClientContract(Guid clientId, string type)
        {
            return new FileDownloadDto
            {
                           FileData = TemplateProcessor.Process(DatabaseContext, clientId, type)
                       };
        }
    }
}
