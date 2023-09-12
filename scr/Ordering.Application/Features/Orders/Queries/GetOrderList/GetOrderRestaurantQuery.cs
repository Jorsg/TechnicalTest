using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrderList
{
	
	public class GetOrderRestaurantQuery : IRequest<List<OrdersVm>>
	{
		public string RestaurantName { get; set; }

        public GetOrderRestaurantQuery(string restaurantName)
        {
			RestaurantName = restaurantName ?? throw new ArgumentNullException(nameof(restaurantName));
        }
    }
}
