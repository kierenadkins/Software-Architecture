using ApplicationLayer.DTO.Application;
using DomainLayer.Objects.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ApplicationLayer.Extentions
{
    public static class ApplicationExtensions
    {
        public static ApplicationDto ToDto(this IApplication application)
        {
            return new ApplicationDto();
        }
    }
}
