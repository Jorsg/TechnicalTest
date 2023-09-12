using Ordering.Domain.Common;
using Ordering.Domain.Common.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Entity
{
	public class Order : EntityBase
	{
        public Guid Id { get; init; }
		public Restaurant Restaurant { get; set; }
		public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderEstimationReadyTime EstimationReadyTime { get; set; }

		
	}
}
