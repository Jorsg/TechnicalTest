﻿using MediatR;
using System;
using System.Collections.Generic;

namespace Ordering.Application.Features.Orders.Queries.GetOrderList
{
    public class GetOrdersListQuery : IRequest<List<OrdersVm>>
    {
        public string UserName { get; set; }
        public int IdRestaurant { get; set; }

        public GetOrdersListQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
           
        }
    }
}
