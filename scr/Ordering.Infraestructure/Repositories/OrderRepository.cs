using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entity;
using Ordering.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infraestructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
	{
		public OrderRepository(OrderContext dbContex) : base(dbContex)
		{
		}
		public async Task<IEnumerable<Order>> GetOrderByUserName(string userName)
		{
			//Logic ... Get order by User Name
			Task.FromResult(new List<Order>());
			return null;
		}
		public async Task<Order> GetOrderByRestaurant(string RestaurantName)
		{
			//Logic ... Get order by Id Restaurant
			Task.FromResult(new Order());
			return null;
		}

		
	}
}
