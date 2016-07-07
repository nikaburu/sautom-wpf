using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using AutoMapper;
using Sautom.Queries;
using Sautom.Server.Interfaces;
using Sautom.Server.TransportDto;

namespace Sautom.Server.Services
{
    //todo T4
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    sealed public class QueriesService : IQueriesService
    {
	    #region Constructors

	    public QueriesService(IMapper mapper, IClientFinder clientFinder, IProposalFinder proposalFinder)
        {
		    Mapper = mapper;
		    ClientFinder = clientFinder;
            ProposalFinder = proposalFinder;
        }

	    #endregion

	    public string CurrentUserName()
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                return Thread.CurrentPrincipal.Identity.Name + " " + 
                    Thread.CurrentPrincipal.IsInRole("Administrator") + " " + Thread.CurrentPrincipal.IsInRole("Manager");
            }

            return string.Empty;
        }

	    #region Properties

	    public IMapper Mapper { get; set; }
	    public IClientFinder ClientFinder { get; }
	    public IProposalFinder ProposalFinder { get; }

	    #endregion

	    #region Client

	    public ICollection<ClientItemDtoOutput> GetAllClients(string personalNumberFilter, string nameRuFilter, string courseNameFilter)
        {
            return Mapper.Map<ICollection<ClientItemDtoOutput>>(ClientFinder.GetAllClients(personalNumberFilter, nameRuFilter, courseNameFilter));
        }

	    public ClientEditDtoOutput GetClientForEdit(Guid clientId)
        {
            return Mapper.Map<ClientEditDtoOutput>(ClientFinder.GetClientForEdit(clientId));
        }

	    public ClientViewDtoOutput GetClientForView(Guid clientId)
        {
            return Mapper.Map<ClientViewDtoOutput>(ClientFinder.GetClientForView(clientId));
        }

	    public CreateOrderInfoDtoOutput GetOrderCreationData()
        {
            return Mapper.Map<CreateOrderInfoDtoOutput>(ClientFinder.GetOrderCreationData());
        }

	    public CreateOrderInfoDtoOutput GetOrderEditData(Guid orderId)
        {
            return Mapper.Map<CreateOrderInfoDtoOutput>(ClientFinder.GetOrderEditData(orderId));
        }

	    public AirlineTicketViewDtoOutput AirlineTicketForView(Guid orderId)
        {
            return Mapper.Map<AirlineTicketViewDtoOutput>(ClientFinder.AirlineTicketForView(orderId));
        }

	    public AirlineTicketEditDtoOutput AirlineTicketForEdit(Guid airlineTickedId)
        {
            return Mapper.Map<AirlineTicketEditDtoOutput>(ClientFinder.AirlineTicketForEdit(airlineTickedId));
        }

	    public ContractViewDtoOutput ContractForView(Guid orderId)
        {
            return Mapper.Map<ContractViewDtoOutput>(ClientFinder.ContractForView(orderId));
        }

	    public ContractEditDtoOutput ContractForEdit(Guid contractId)
        {
            return Mapper.Map<ContractEditDtoOutput>(ClientFinder.ContractForEdit(contractId));
        }

	    #endregion

	    #region Proposal

	    public ICollection<ProposalDtoOutput> GetAllProposals(bool? isGrouptFilter, string countryFilter, string schoolNameFilter, string courseNameFilter)
        {
            return Mapper.Map<ICollection<ProposalDtoOutput>>(ProposalFinder.GetAll(isGrouptFilter, countryFilter, schoolNameFilter, courseNameFilter));
        }

	    public ProposalEditDtoOutput GetProposalForEdit(Guid proposalId)
        {
            return Mapper.Map<ProposalEditDtoOutput>(ProposalFinder.GetProposalForEdit(proposalId));
        }

	    public ICollection<CountryItemDtoOutput> GetAllCountries()
        {
            return Mapper.Map<ICollection<CountryItemDtoOutput>>(ProposalFinder.GetAllCountries());
        }

	    public CountryEditDtoOutput GetCountryForEdit(Guid countryId)
        {
            return Mapper.Map<CountryEditDtoOutput>(ProposalFinder.GetCountryForEdit(countryId));
        }

	    public ICollection<CountryWitCitiesDtoOutput> GetAllCountriesWithCities()
        {
            return Mapper.Map<ICollection<CountryWitCitiesDtoOutput>>(ProposalFinder.GetAllCountriesWithCities());
        }

	    public ICollection<RateItemDtoOutput> GetRatesList()
        {
            return Mapper.Map<ICollection<RateItemDtoOutput>>(ProposalFinder.GetRatesList());
        }

	    public ICollection<string> GetCourceNames(string startsWith)
        {
            return ProposalFinder.GetCourceNames(startsWith);
        }

	    public ICollection<string> GetSchoolNames(string startsWith, Guid cityId)
        {
            return ProposalFinder.GetSchoolNames(startsWith, cityId);
        }

	    #endregion
    }
}
