using DomainLayer.ValueObjects.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Objects.Visas
{
    public class CountryVisas : ICountryVisas
    {
        internal CountryVisas(List<IVisa> visas)
        {
            Visas = visas;
        }

        public List<IVisa> Visas { get; init ; }

        public Visa GetVisa(string type)
        {
            return (Visa)Visas.First(x => x.Type.Value == type);
        }
    }
}
