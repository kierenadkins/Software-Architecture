using DomainLayer.Contracts.Infrastructure;
using DomainLayer.Objects.Users;
using DomainLayer.Objects.Visas;
using DomainLayer.ValueObjects.Users;
using InfrastructureLayer.Documents.UserDocuments;
using InfrastructureLayer.Mappers.Users;
using InfrastructureLayer.Mappers.Visas;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repository
{
    //Although this technically connects to our database, i have pre defined the suggestion data and application templates 
    //this is an example on how the system would intergrate with the extenral system, rather than having to code a seperate
    //system up for this use case.

    // we can pertend that this "REPO" is an external system for the proof of concept
    public class VisaIntegrationService : IVisaIntegrationService
    {
        private readonly IRepository<VisaDocument> _visaRepo;
        private readonly IVisaMapper _visaMapper;
        public VisaIntegrationService(IRepository<VisaDocument> visaRepo, IVisaMapper visaMapper)
        {
            _visaRepo = visaRepo;
            _visaMapper = visaMapper;
        }

        public Task<ICountryVisas> FindCountriesVisas(string country)
        {
            throw new NotImplementedException();
        }

        public async Task<IVisa?> GetSuggestion(string country, string type, string countryOfOrgin)
        {

              var suggestion = await _visaRepo
                    .GetAsync(x => x.Country == country && x.VisaType == type && x.ElgibilityRules.EligibleCountires.Contains(countryOfOrgin))
                    .FirstOrDefaultAsync();


            if (suggestion is null)
            {
                return null;
            }

            return _visaMapper.ToVisaModel(suggestion)  ;
        }

        public Task<IVisa> GetVisa(string id)
        {
            throw new NotImplementedException();
        }

        public async Task SAVE(IVisa visa)
        {
            await _visaRepo.CreateAsync(_visaMapper.ToVisaDocument(visa));
        }
    }
}
