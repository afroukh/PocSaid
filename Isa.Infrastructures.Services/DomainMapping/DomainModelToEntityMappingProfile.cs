using DM = Isa.Core.Services.DomainModels;
using EM = Isa.Core.Repositories.EntityModels;
using AutoMapper;

namespace AideCaviardage.Services.DomainMapping
{
    public class DomainModelToEntityMappingProfile: Profile
    {
        public override string ProfileName => "DomainModelToEntityMapping";

        public DomainModelToEntityMappingProfile()
        {
           
        }
    }
}
