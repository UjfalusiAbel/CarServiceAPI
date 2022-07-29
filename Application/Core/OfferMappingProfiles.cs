using AutoMapper;
using Domain;

namespace Application.Core
{
    public class OfferMappingProfiles:Profile
    {
        public OfferMappingProfiles()
        {
            CreateMap<Offer,Offer>();
        }
    }
}