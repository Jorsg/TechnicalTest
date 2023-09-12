using Ordering.Domain.Common;
using Ordering.Domain.Common.ValueObject;
using Ordering.Domain.Entity;

namespace Ordering.Application.Features.Orders.Queries.GetOrderList
{
    public class OrdersVm
    {
		public Guid Id { get; init; }
		public Restaurant Restaurant { get; set; }
		public Customer Customer { get; set; }
		public List<OrderItem> OrderItems { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public OrderEstimationReadyTime EstimationReadyTime { get; set; }
	}
}
