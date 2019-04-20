using DM = Isa.Core.Services.DomainModels;
using EM = Isa.Core.Repositories.EntityModels;
using AutoMapper;

namespace AideCaviardage.Services.DomainMapping
{
    public class EntityToDomainModelMappingProfile : Profile
    {
        public override string ProfileName => "EntityToDomainModelMapping";

        public EntityToDomainModelMappingProfile()
        {
           
        }
    }
}
