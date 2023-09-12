using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrderList
{
	public class GetOrdersRestaurantQueryHandler : IRequestHandler<GetOrderRestaurantQuery, List<OrdersVm>>
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IMapper _mapper;

		public GetOrdersRestaurantQueryHandler(IOrderRepository orderRepository, IMapper mapper)
		{
			_orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}
		public async Task<List<OrdersVm>> Handle(GetOrderRestaurantQuery request, CancellationToken cancellationToken)
		{

			var orderList = await _orderRepository.GetOrderByRestaurant(request.RestaurantName);
			return _mapper.Map<List<OrdersVm>>(orderList);
		}
	}
}
