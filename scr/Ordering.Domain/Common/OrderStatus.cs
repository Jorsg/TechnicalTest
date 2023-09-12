using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Common
{
	public enum OrderStatus
	{
		Placed = 0,
		Preparing =	1,
		Ready = 2,
		Canceled = 3,
	}
}
