using DomainLayer.Contracts.Infrastructure;
using DomainLayer.Objects.Applications;
using DomainLayer.Objects.Users;
using DomainLayer.Objects.Visas;
using DomainLayer.ValueObjects.Users;
using InfrastructureLayer.Documents.ApplicationDocuments;
using InfrastructureLayer.Documents.UserDocuments;
using InfrastructureLayer.Mappers.Applications;
using InfrastructureLayer.Mappers.Users;
using InfrastructureLayer.Mappers.Visas;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        private readonly IRepository<ApplicationDocument> _applicationRepo;
        private readonly IVisaMapper _visaMapper;
        private readonly IApplicationMapper _applicationMapper;
        public VisaIntegrationService(IRepository<VisaDocument> visaRepo, IRepository<ApplicationDocument> applicationRepo, IVisaMapper visaMapper, IApplicationMapper applicationMapper)
        {
            _visaRepo = visaRepo;
            _applicationRepo = applicationRepo;
            _visaMapper = visaMapper;
            _applicationMapper = applicationMapper;
        }

        public async Task<List<IVisa>?> FindCountriesVisas(string country, string countryOfOrgin)
        {
            var visasdocsList = await _visaRepo.PageAsync(x => x.Country == country && x.ElgibilityRules.EligibleCountires.Contains(countryOfOrgin), pageSize: 10, continuationToken: null);

            if (visasdocsList is null || visasdocsList.Items.Count == 0)
            {
                return null;
            }

            return visasdocsList.Items.Select(x => _visaMapper.ToVisaModel(x)).ToList();
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

        public async Task<IVisa?> GetVisa(string id)
        {
            var suggestion = await _visaRepo
                    .GetAsync(x => x.PartitionKey == id)
                    .FirstOrDefaultAsync();


            if (suggestion is null)
            {
                return null;
            }

            return _visaMapper.ToVisaModel(suggestion);
        }

        public async Task<IApplication?> GetApplication(string visaId)
        {
            var application = await _applicationRepo.GetAsync(x => x.VisaId == visaId).FirstOrDefaultAsync();

            if(application is null)
            {
                return null;
            }

            return _applicationMapper.ToApplication(application);
            
        }
    }
}
