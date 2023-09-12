using Ordering.Domain.Common;
using Ordering.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class NotificationCheckoutEvent : IntegrationBaseEvent
    {
		public Guid Id { get; init; }
		public Guid IdRestaurant { get; set; }
		public Guid IdCustomer { get; set; }
		public List<OrderItem> OrderItems { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public DateTime EstimationReadyTime { get; set; }

	}
}
