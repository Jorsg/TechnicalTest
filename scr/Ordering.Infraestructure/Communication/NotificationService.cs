using MassTransit;
using MassTransit.Transports;
using Ordering.Application.Contracts.Infraestructure;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infraestructure.Communication
{
	public class NotificationService : INotificationService
	{
		private readonly IBusControl _busControl;
		private readonly IOrderRepository _orderRepository;

		public NotificationService(IBusControl busControl)
		{
			_busControl = busControl;
		}
		public async Task SendOrderNotification(Order order)
		{
			string message = GenerateNotificationMessage(order);
			 await _busControl.Publish(
				new NotificationMessage
				{
					Order = order,
					Messages = message
				}
				); ;			
		}
		private string GenerateNotificationMessage(Order order)
		{
			// Lógica para generar el mensaje de notificación
			string restaurantName = GetRestaurantName(order);
			string userName = GetUserName(order);
			string formattedTime = FormatTime(order.EstimationReadyTime.Value);

			return $"{restaurantName}: Hi {userName}, your order will be ready at {formattedTime}";
		}

		private string GetRestaurantName(Order order)
		{
			// Lógic to get the restaurant name
			// ...
			return  _orderRepository.GetOrderByRestaurant(order.Restaurant.Name).ToString();
			
		}

		private string GetUserName(Order order)
		{
			// Lógica para obtener el nombre del usuario desde la base de datos o servicio externo
			// ...
			return _orderRepository.GetOrderByUserName(order.Restaurant.Name).ToString(); ;
		}

		private string FormatTime(DateTime time)
		{
			// Lógica to format date (example, "HH:mm")
			// ...
			return null;
		}
	}
}
