using AutoMapper;
using DotzMVP.Lib.Infrastructure.Data.Model;
using DotzMVP.Model.Change;
using DotzMVP.Model.Customer;
using DotzMVP.Model.Product;
using DotzMVP.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotzMVP.Infrastructure.Mapping
{
    public class MappingData : Profile
    {
        public MappingData()
        {
            #region User
            CreateMap<UserCreateRequest, User>();
            CreateMap<User, UserCreateResponse>();
            #endregion

            #region UserAdmin
            CreateMap<UserCreateRequest, UserAdmin>();
            CreateMap<UserAdmin, UserCreateResponse>();
            #endregion

            #region Customer
            CreateMap<CustomerCreateRequest, Customer>();
            CreateMap<Customer, CustomerCreateResponse>();
            #endregion

            #region Address
            CreateMap<AddressUserRequest, Address>();
            #endregion

            #region Product
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
            #endregion

            #region Score
            CreateMap<UserRegisterScoreRequest, Score>();
            CreateMap<Score, UserRegisterScoreResponse>();
            #endregion
            #region Change
            CreateMap<ChangeCreateRequest, ChangeRegister>()
                .ForMember(dest => dest.Itens, m => m.MapFrom(x => x.Itens));
            CreateMap<ChangeCreateRequestItem, ChangeRegisterItem>();
            CreateMap<ChangeRegister, UserChangeListResponse>()
                .ForMember(dest => dest.Amount, m => m.MapFrom(x => x.Itens.Select(x => (x.Price * x.Amount)).ToList().Sum()))
                .ForMember(dest => dest.CreatedDate, m => m.MapFrom(x => x.CreatedAt));
            #endregion
        }
    }
}
