using AutoMapper;
using Domain;

namespace Application.Core
{
    public class ReviewMappingProfiles:Profile
    {
        public ReviewMappingProfiles()
        {
            CreateMap<Review,Review>();
        }
    }
}