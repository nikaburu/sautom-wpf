using System;
using Prism.Events;
using Sautom.Client.Comunication.QueriesService;

namespace Sautom.Client.Comunication.Services
{
    internal class QueriesServiceAdapter : BaseServiceAdapter, IQueriesService
    {
        #region Properties
        private QueriesServiceClient ServiceClient { get; set; }
        #endregion

        #region Constructors
        public QueriesServiceAdapter(QueriesServiceClient client, IEventAggregator eventAggregator) : base(eventAggregator)
        {
            ServiceClient = client;
        }
        #endregion

        #region Implementation of IQueriesService

        public ClientItemDtoOutput[] GetAllClients(string personalNumberFilter, string nameRuFilter, string courseNameFilter)
        {
            return ExceptionAware(() => ServiceClient.GetAllClients(personalNumberFilter, nameRuFilter, courseNameFilter), () => new ClientItemDtoOutput[0]);
        }
        
        public ClientEditDtoOutput GetClientForEdit(Guid clientId)
        {
            return ExceptionAware(() => ServiceClient.GetClientForEdit(clientId));
        }

        public ClientViewDtoOutput GetClientForView(Guid clientId)
        {
            return ExceptionAware(() => ServiceClient.GetClientForView(clientId));
        }

        public ContractEditDtoOutput ContractForEdit(Guid contractId)
        {
            return ExceptionAware(() => ServiceClient.ContractForEdit(contractId));
        }

        public string CurrentUserName()
        {
            return ExceptionAware(() => ServiceClient.CurrentUserName());
        }
        
        public ProposalDtoOutput[] GetAllProposals(bool? isGrouptFilter, string countryFilter, string schoolNameFilter, string courseNameFilter)
        {
            return ExceptionAware(() => ServiceClient.GetAllProposals(isGrouptFilter, countryFilter, schoolNameFilter, countryFilter), () => new ProposalDtoOutput[0]);
        }

        public ProposalEditDtoOutput GetProposalForEdit(Guid proposalId)
        {
            return ExceptionAware(() => ServiceClient.GetProposalForEdit(proposalId));
        }

        public CountryItemDtoOutput[] GetAllCountries()
        {
            return ExceptionAware(() => ServiceClient.GetAllCountries());
        }

        public CountryEditDtoOutput GetCountryForEdit(Guid countryId)
        {
            return ExceptionAware(() => ServiceClient.GetCountryForEdit(countryId));
        }

        public CountryWitCitiesDtoOutput[] GetAllCountriesWithCities()
        {
            return ExceptionAware(() => ServiceClient.GetAllCountriesWithCities(), () => new CountryWitCitiesDtoOutput[0]);
        }

        public RateItemDtoOutput[] GetRatesList()
        {
            return ExceptionAware(() => ServiceClient.GetRatesList(), () => new RateItemDtoOutput[0]);
        }

        public string[] GetCourceNames(string startsWith)
        {
            return ExceptionAware(() => ServiceClient.GetCourceNames(startsWith), () => new string[0]);
        }

        public string[] GetSchoolNames(string startsWith, Guid cityId)
        {
            return ExceptionAware(() => ServiceClient.GetSchoolNames(startsWith, cityId), () => new string[0]);
        }
        
        public CreateOrderInfoDtoOutput GetOrderCreationData()
        {
            return ExceptionAware(() => ServiceClient.GetOrderCreationData());
        }

        public CreateOrderInfoDtoOutput GetOrderEditData(Guid orderId)
        {
            return ExceptionAware(() => ServiceClient.GetOrderEditData(orderId));
        }

        public AirlineTicketViewDtoOutput AirlineTicketForView(Guid orderId)
        {
            return ExceptionAware(() => ServiceClient.AirlineTicketForView(orderId));
        }

        public AirlineTicketEditDtoOutput AirlineTicketForEdit(Guid airlineTickedId)
        {
            return ExceptionAware(() => ServiceClient.AirlineTicketForEdit(airlineTickedId));
        }

        public ContractViewDtoOutput ContractForView(Guid orderId)
        {
            return ExceptionAware(() => ServiceClient.ContractForView(orderId));
        }

        #endregion
    }
}
