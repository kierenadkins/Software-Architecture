using DomainLayer.Objects.Users;
using DomainLayer.Objects.Visas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracts.Infrastructure
{
    public interface IVisaIntegrationService
    {
        Task<IVisa?> GetSuggestion(string destination,string reason, string countryOfOrgin);
        Task<List<IVisa>?> FindCountriesVisas (string country, string countryOfOrgin);
        Task<IVisa> GetVisa(string id);

        Task SAVE(IVisa visa);

    }
}
