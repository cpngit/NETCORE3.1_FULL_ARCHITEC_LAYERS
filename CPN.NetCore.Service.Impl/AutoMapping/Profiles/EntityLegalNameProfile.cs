using AutoMapper;
using CPN.NetCore.DTO;
using CPN.NetCore.Entity;

namespace CPN.NetCore.Service.Impl.Profiles
{
    public class LnkProfileProfile : Profile
    {
        public LnkProfileProfile()
        {
            CreateMap<LnkProfile, LnkProfileDTO>()
            .ReverseMap();
         
        }
    }
}