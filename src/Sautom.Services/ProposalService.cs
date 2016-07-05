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
    public sealed class ProposalService
    {
	    #region Constructors

	    public ProposalService(IMapper mapper, IUnitOfWorkFactory unitOfWorkFactory, IProposalRepository proposalRepository, ICountryRepository countryRepository, ICityRepository cityRepository, IEmbassyDocumentRepository documentRepository, IRateRepository rateRepository)
        {
	        Mapper = mapper;
	        ProposalRepository = proposalRepository;
            CountryRepository = countryRepository;
            CityRepository = cityRepository;
            DocumentRepository = documentRepository;
            RateRepository = rateRepository;
            UnitOfWorkFactory = unitOfWorkFactory;
        }

	    #endregion

	    public ICommandState EditOrAddProposal(ProposalEditDto data)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                if (data.Id == Guid.Empty)
                {
                    CreateProposal(data);
                }
                else
                {
                    Proposal proposal = ProposalRepository.Get(data.Id);
                    if (proposal == null)
                    {
                        CreateProposal(data);
                    }
                    else
                    {
                        UpdateProposal(proposal, data);
                    }
                }

                uow.Commit();

                return new DefaultCommandState { IsValid = true, State = new Dictionary<string, object>() };
            }
        }

	    public ICommandState EditOrAddCountry(CounrtyEditDto data)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                if (data.Id == Guid.Empty)
                {
                    CreateCountryInternal(data);
                }
                else
                {
                    Country country = CountryRepository.Get(data.Id);
                    if (country == null)
                    {
                        CreateCountryInternal(data);
                    }
                    else
                    {
                        UpdateCountryInternal(country, data);
                    }
                }

                uow.Commit();

                return new DefaultCommandState { IsValid = true, State = new Dictionary<string, object>() };
            }
        }

	    public ICommandState EditOrAddRate(RateItemDto data)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                Rate rate = RateRepository.Get(data.Id);
                if (rate == null)
                {
                    rate = Mapper.Map<Rate>(data);
                    RateRepository.Add(rate);
                }
                else
                {
                    rate = Mapper.Map(data, rate);
                    RateRepository.Update(rate);
                }

                uow.Commit();

                return new DefaultCommandState { IsValid = true, State = new Dictionary<string, object>() };
            }
        }

	    #region Properties

	    private IMapper Mapper { get; }
	    private IProposalRepository ProposalRepository { get; }
	    private ICountryRepository CountryRepository { get; }
	    private ICityRepository CityRepository { get; }
	    private IEmbassyDocumentRepository DocumentRepository { get; }
	    private IRateRepository RateRepository { get; }
	    private IUnitOfWorkFactory UnitOfWorkFactory { get; }

	    #endregion

	    #region Private members

	    private void UpdateProposal(Proposal proposal, ProposalEditDto data)
        {
            Mapper.Map(data, proposal);

            proposal.City = CityRepository.Get(data.CityId);
            proposal.AvailableHouseTypes.Clear();
            proposal.AvailableHouseTypes = ProposalRepository.GetHousingTypes(data.HouseTypes.ToArray());

            proposal.AvailableIntensities.Clear();
            proposal.AvailableIntensities = ProposalRepository.GetIntensityTypes(data.Intensities.ToArray());

            ProposalRepository.Update(proposal);
        }

	    private void CreateProposal(ProposalEditDto data)
        {
            Proposal proposal = Mapper.Map<Proposal>(data);

            proposal.City = CityRepository.Get(data.CityId);
            proposal.AvailableHouseTypes = ProposalRepository.GetHousingTypes(data.HouseTypes.ToArray());
            proposal.AvailableIntensities = ProposalRepository.GetIntensityTypes(data.Intensities.ToArray());

            ProposalRepository.Add(proposal);
        }

	    private void UpdateCountryInternal(Country country, CounrtyEditDto data)
        {
            Mapper.Map(data, country);
            
            //Cities
            List<CityItemDto> newCities = data.Cities.Where(rec => rec.Id == Guid.Empty).ToList();
            newCities.ForEach(city => CityRepository.Add(new City
            {
                                                                 CityName = city.CityName,
                                                                 Country = country
                                                             }));
            List<City> editedCities = country.Cities.Where(rec => !newCities.Any(cc => cc.Id == rec.Id)).ToList();
            editedCities.ForEach(doc => doc.CityName = data.Cities.First(rec => rec.Id == doc.Id).CityName);

            //Embassy docs
            List<EmbassyDocumentItemDto> newDocs = data.EmbassyDocuments.Where(rec => rec.Id == Guid.Empty).ToList();
            List<EmbassyDocument> delectedDocs = country.EmbassyDocuments
                .Where(rec => rec.Id != Guid.Empty && !data.EmbassyDocuments.Any(dd => dd.Id == rec.Id)).ToList();
            List<EmbassyDocument> editedDocs = country.EmbassyDocuments.Where(rec => !delectedDocs.Contains(rec)).ToList();

            newDocs.ForEach(doc => DocumentRepository.Add(new EmbassyDocument
            {
                                                                       DocumentName = doc.DocumentName,
                                                                       Country = country
                                                                   }));
            editedDocs.ForEach(doc =>
                                   {
                                       EmbassyDocumentItemDto d = data.EmbassyDocuments.First(rec => rec.Id == doc.Id);
                                       doc.DocumentName =d.DocumentName;
                                       doc.IsArchival = d.IsArchival;

                                   });
            delectedDocs.ForEach(DocumentRepository.Delete);
            
            CountryRepository.Update(country);
        }

	    private void CreateCountryInternal(CounrtyEditDto data)
        {
            Country country = Mapper.Map<Country>(data);

            CountryRepository.Add(country);
        }

	    #endregion
    }
}
