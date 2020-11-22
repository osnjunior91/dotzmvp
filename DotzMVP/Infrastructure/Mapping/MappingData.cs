using AutoMapper;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Model.User;

namespace DotzMVP.Infrastructure.Mapping
{
    public class MappingData : Profile
    {
        public MappingData()
        {
            CreateMap<UserRequest, User>();
        }
    }
}
