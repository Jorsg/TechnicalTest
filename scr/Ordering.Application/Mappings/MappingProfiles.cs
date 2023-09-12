﻿using AutoMapper;
using Ordering.Application.Features.Orders.Commands.CheckoutOrde;
using Ordering.Application.Features.Orders.Queries.GetOrderList;
using Ordering.Domain.Entity;

namespace Ordering.Application.Mappings
{
	public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
           
        }
    }
}
