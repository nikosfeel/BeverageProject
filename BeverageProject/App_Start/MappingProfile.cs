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

            Mapper.CreateMap<Wine, WineDto>();
            Mapper.CreateMap<WineDto, Wine>();

            Mapper.CreateMap<Beer, BeerDto>();
            Mapper.CreateMap<BeerDto, Beer>();


            Mapper.CreateMap<Spirit, SpiritDto>();
            Mapper.CreateMap<SpiritDto, Spirit>();


            Mapper.CreateMap<Whiskey, WhiskeyDto>();
            Mapper.CreateMap<WhiskeyDto, Whiskey>();




        }

    }
}