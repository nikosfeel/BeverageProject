using AutoMapper;
using Web.Models.Dtos;
using Entities.Orders;
using Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Order, OrderDto>();
            Mapper.CreateMap<OrderDto, Order>();

            Mapper.CreateMap<Product, WineDto>();
            Mapper.CreateMap<WineDto, Product>();

        }

    }
}