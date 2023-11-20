using ApplicationLayer.DTO.Application;
using DomainLayer.Objects.Applications;
using DomainLayer.Objects.Visas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Extentions
{
    public static class VisaExtensions
    {
        public static ApplicationDto ToDto(this IVisa visa)
        {
            return new ApplicationDto();
        }
    }
}
