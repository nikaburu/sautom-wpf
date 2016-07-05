using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Sautom.Domain.Entities;
using Sautom.Services.Dto;
using Sautom.Services.Repositories;
using Sautom.Services.UnitOfWork;

namespace Sautom.Services
{
    public sealed class ClientService
    {
	    #region Constructors

	    public ClientService(IMapper mapper, IUnitOfWorkFactory unitOfWorkFactory, IClientRepository clientRepository, 
            IProposalRepository proposalRepository, IOrderRepository orderRepository, 
            IManagerRepository managerRepository, IEmbassyDocumentRepository documentRepository,
            IAirlineTicketRepository airlineTicketRepository, IContractRepository contractRepository, 
            IAuthorizationRepository authorizationRepository)
        {
	        Mapper = mapper;
	        ClientRepository = clientRepository;
            UnitOfWorkFactory = unitOfWorkFactory;
            ProposalRepository = proposalRepository;
            OrderRepository = orderRepository;
            ManagerRepository = managerRepository;
            DocumentRepository = documentRepository;
            AirlineTicketRepository = airlineTicketRepository;
            ContractRepository = contractRepository;
            AuthorizationRepository = authorizationRepository;
        }

	    #endregion

	    public ICommandState AddClientComment(Guid clientId, string comment, string currentUserName)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                Client client = ClientRepository.Get(clientId);

                client.Comments.Add(new ManagerComment
                {
                                            Id = Guid.NewGuid(),
                                            Comment = comment,
                                            Date = DateTime.Now,
                                            Manager = ManagerRepository.GetManagerByName(currentUserName),
                                            Client = client
                                        });

                uow.Commit();
            }

            return new DefaultCommandState { IsValid = true };
        }

	    public ICommandState EditOrAddClient(Guid clientId, ClientEditDto clientData)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                if (clientId == Guid.Empty)
                {
                    CreateClientInternal(clientData);
                }
                else
                {
                    Client client = ClientRepository.Get(clientId);
                    if (client == null)
                    {
                        CreateClientInternal(clientData);
                    }

                    UpdateClientInternal(client, clientData);
                }
                
                uow.Commit();

                return new DefaultCommandState { IsValid = true };
            }
        }

	    public ICommandState AddOrder(Guid clientId, OrderEditDto orderData)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                if (clientId == Guid.Empty) return new DefaultCommandState { IsValid = false };

                Client client = ClientRepository.Get(clientId);
                CreateOrderForClientInternal(client, orderData);

                uow.Commit();
            }

            return new DefaultCommandState { IsValid = true };
        }

	    public ICommandState UpdateOrder(OrderEditDto orderData)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                UpdateOrderInternal(orderData, true);

                uow.Commit();
            }
            
            return new DefaultCommandState { IsValid = true };
        }

	    public ICommandState BulkUpdateOrders(ICollection<OrderEditDto> orders)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                foreach (OrderEditDto order in orders)
                {
                    UpdateOrderInternal(order);
                }

                uow.Commit();
            }

            return new DefaultCommandState { IsValid = true };
        }

	    public ICommandState EditOrAddContract(ContractEditDto data)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                Contract contract = ContractRepository.Get(data.Id);
                if (contract == null)
                {
                    contract = Mapper.Map<Contract>(data);
                    contract.Order = OrderRepository.Get(data.OrderId);

                    ContractRepository.Add(contract);
                }
                else
                {
                    Mapper.Map(data, contract);

                    ContractRepository.Update(contract);
                }

                uow.Commit();
            }
            
            return new DefaultCommandState { IsValid = true };
        }

	    public ICommandState EditOrAddAirlineTicket(AirlineTicketEditDto data)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                AirlineTicket ticket = AirlineTicketRepository.Get(data.Id);
                if (ticket == null)
                {
                    ticket = Mapper.Map<AirlineTicket>(data);
                    ticket.Order = OrderRepository.Get(data.OrderId);

                    AirlineTicketRepository.Add(ticket);
                }
                else
                {
                    Mapper.Map(data, ticket);

                    AirlineTicketRepository.Update(ticket);
                }
                
                uow.Commit();
            }
            
            return new DefaultCommandState { IsValid = true };
        }

	    #region Dependencies

	    private IMapper Mapper { get; }
	    private IClientRepository ClientRepository { get; }
	    private IOrderRepository OrderRepository { get; }
	    private IManagerRepository ManagerRepository { get; }
	    private IEmbassyDocumentRepository DocumentRepository { get; }
	    private IAirlineTicketRepository AirlineTicketRepository { get; }
	    private IContractRepository ContractRepository { get; }
	    private IAuthorizationRepository AuthorizationRepository { get; set; }
	    private IUnitOfWorkFactory UnitOfWorkFactory { get; }
	    private IProposalRepository ProposalRepository { get; }

	    #endregion

	    #region Private members

	    private void UpdateOrderInternal(OrderEditDto data, bool isFullyUpdate = false)
        {
            Order order = OrderRepository.Get(data.Id);
            order.EmbassyDate = data.EmbassyDate;
            order.VisaDate = data.VisaDate;
            order.IsEmbassyChecked = data.IsEmbassyChecked.GetValueOrDefault();

            order.EmbassyDocuments.Clear();
            order.EmbassyDocuments = DocumentRepository.GetMany(data.EmbassyDocs.ToArray());

            if (isFullyUpdate)
            {
                order.ResponsibleManager = ManagerRepository.Get(data.ManagerId);

                order.StartDate = data.StartDate;
                order.EndDate = data.EndDate;
                order.Intensity = ProposalRepository.GetIntensityTypes(data.IntensityId).First();
                order.HouseType = ProposalRepository.GetHousingTypes(data.HouseTypeId).First();
            }

            OrderRepository.Update(order);
        }

	    private Client CreateClientInternal(ClientEditDto data)
        {
            Client client = Mapper.Map<Client>(data);
            client.Parent = new ClientParent
            {
                                    Address = data.ParentAddress,
                                    Name = data.ParentName,
                                    PassportInfo = data.ParentPassportInfo,
                                    Phone = data.ParentPhone
                                };

            ClientRepository.Add(client);

            return client;
        }

	    private void CreateOrderForClientInternal(Client client, OrderEditDto orderData)
        {
            Order order = new Order
            {
                Client = client,
                Proposal = ProposalRepository.Get(orderData.ProposalId),
                ResponsibleManager = ManagerRepository.Get(orderData.ManagerId),
                Intensity = ProposalRepository.GetIntensityTypes(orderData.IntensityId).First(),
                HouseType = ProposalRepository.GetHousingTypes(orderData.HouseTypeId).First(),
                StartDate = orderData.StartDate,
                EndDate = orderData.EndDate
            };

            OrderRepository.Add(order);
        }

	    private void UpdateClientInternal(Client client, ClientEditDto data)
        {
            Mapper.Map(data, client);

            ClientParent parent = new ClientParent
            {
                                 Address = data.ParentAddress,
                                 Name = data.ParentName,
                                 PassportInfo = data.ParentPassportInfo,
                                 Phone = data.ParentPhone
                             };

            client.Parent = Mapper.Map(parent, client.Parent);

            ClientRepository.Update(client);
        }

	    #endregion
    }
}
