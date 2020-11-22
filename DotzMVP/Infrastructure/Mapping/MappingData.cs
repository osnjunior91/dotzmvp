using AutoMapper;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Model.Customer;
using DotzMVP.Model.User;

namespace DotzMVP.Infrastructure.Mapping
{
    public class MappingData : Profile
    {
        public MappingData()
        {
            #region User
            CreateMap<UserCreateRequest, User>();
            #endregion

            #region Customer
            CreateMap<CustomerCreateRequest, Customer>();
            #endregion
        }
    }
}
