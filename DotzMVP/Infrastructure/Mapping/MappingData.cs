using AutoMapper;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Model.Change;
using DotzMVP.Model.Customer;
using DotzMVP.Model.Product;
using DotzMVP.Model.User;
using System;
using System.Collections.Generic;

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

            #region Address
            CreateMap<AddressUserRequest, Address>();
            #endregion

            #region Product
            CreateMap<CreateProductRequest, Product>();
            #endregion

            #region Score
            CreateMap<UserRegisterScoreRequest, Score>();
            #endregion
            #region Change
            CreateMap<ChangeCreateRequest, ChangeRegister>()
                .ForMember(dest => dest.PersonID, m => m.MapFrom(x => x.UserID))
                .ForMember(dest => dest.Itens, m => m.MapFrom(x => x.Itens));

            CreateMap<ChangeCreateRequestItem, ChangeRegisterItem>();
            #endregion
        }
    }
}
