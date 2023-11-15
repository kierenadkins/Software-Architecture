using DomainLayer.ValueObjects.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Objects.Visas
{
    public interface ICountryVisas
    {
        List<Visa> visas { get; init; }

        Visa GetVisa(string id);
    }
}
