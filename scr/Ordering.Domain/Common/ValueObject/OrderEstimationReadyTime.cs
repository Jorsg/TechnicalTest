using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Common.ValueObject
{
	public class OrderEstimationReadyTime
	{
		public DateTime Value { get; set; }
		internal OrderEstimationReadyTime(DateTime value) 
		{
			this.Value = value;
		}

		public static OrderEstimationReadyTime Create(DateTime date)
		{
			EstimationTimeOrder(date);
			if (date == DateTime.MinValue)
			{
				return new OrderEstimationReadyTime(date);
			}
			return null;
			
		}
		private static DateTime EstimationTimeOrder(DateTime date)
		{
			//Logic to estimation ready to Order
			return DateTime.UtcNow;
		}

	}
}
