using System;
using System.Collections.Generic;
using System.ServiceModel;
using Sautom.Server.TransportDto;

namespace Sautom.Server.Interfaces
{
    [ServiceContract]
    public interface IQueriesService
    {
	    [OperationContract]
        string CurrentUserName();

	    #region Client

	    [OperationContract]
        ICollection<ClientItemDtoOutput> GetAllClients(string personalNumberFilter, string nameRuFilter, string courseNameFilter);

	    [OperationContract]
        ClientEditDtoOutput GetClientForEdit(Guid clientId);

	    [OperationContract]
        ClientViewDtoOutput GetClientForView(Guid clientId);

	    [OperationContract]
        CreateOrderInfoDtoOutput GetOrderCreationData();

	    [OperationContract]
        CreateOrderInfoDtoOutput GetOrderEditData(Guid orderId);

	    [OperationContract]
        AirlineTicketViewDtoOutput AirlineTicketForView(Guid orderId);

	    [OperationContract]
        AirlineTicketEditDtoOutput AirlineTicketForEdit(Guid airlineTickedId);

	    [OperationContract]
        ContractViewDtoOutput ContractForView(Guid orderId);

	    [OperationContract]
        ContractEditDtoOutput ContractForEdit(Guid contractId);

	    #endregion

	    #region Proposal

	    [OperationContract]
        ICollection<ProposalDtoOutput> GetAllProposals(bool? isGrouptFilter = null, string countryFilter = null, string schoolNameFilter = null, string courseNameFilter = null);

	    [OperationContract]
        ProposalEditDtoOutput GetProposalForEdit(Guid proposalId);

	    [OperationContract]
        ICollection<CountryItemDtoOutput> GetAllCountries();

	    [OperationContract]
        CountryEditDtoOutput GetCountryForEdit(Guid countryId);

	    [OperationContract]
        ICollection<CountryWitCitiesDtoOutput> GetAllCountriesWithCities();

	    [OperationContract]
        ICollection<RateItemDtoOutput> GetRatesList();

	    [OperationContract]
        ICollection<string> GetCourceNames(string startsWith);

	    [OperationContract]
        ICollection<string> GetSchoolNames(string startsWith, Guid cityId);

	    #endregion
    }
}
