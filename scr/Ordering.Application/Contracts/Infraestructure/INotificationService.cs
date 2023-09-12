using Ordering.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Infraestructure
{
	public interface INotificationService
	{
		Task SendOrderNotification(Order order);
	}
}
