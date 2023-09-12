using MediatR;
using Ordering.Domain.Common;
using Ordering.Domain.Common.ValueObject;
using Ordering.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrde
{
    public class CheckoutOrderCommand : IRequest<int>
    {
		public Guid Id { get; init; }
		public Restaurant Restaurant { get; set; }
		public Customer Customer { get; set; }
		public List<OrderItem> OrderItems { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public OrderEstimationReadyTime EstimationReadyTime { get; set; }
	}
}
