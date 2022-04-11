using AutoMapper;
using BeverageProject.Models.Dtos;
using Entities.Orders;
using Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeverageProject.App_Start
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