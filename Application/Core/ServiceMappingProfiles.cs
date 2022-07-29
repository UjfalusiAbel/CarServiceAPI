using AutoMapper;
using Domain;

namespace Application.Core
{
    public class ServiceMappingProfiles:Profile
    {
        public ServiceMappingProfiles()
        {
            CreateMap<Service,Service>();
        }
    }
}