using DomainLayer.Objects.Applications;
using InfrastructureLayer.Documents.ApplicationDocuments;
using System;

namespace InfrastructureLayer.Mappers.Applications
{
    public interface IApplicationMapper
    {

        ApplicationDocument ToApplicationDocument(IApplication application);

        IApplication ToApplication(ApplicationDocument application);
    }
}
