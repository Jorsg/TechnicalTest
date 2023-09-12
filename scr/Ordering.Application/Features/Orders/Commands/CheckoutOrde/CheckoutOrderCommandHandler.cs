using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Infraestructure;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Models;
using Ordering.Domain.Entity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrde
{
	public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IMapper _mapper;
		private readonly IEmailService _emailService;


		public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IEmailService emailService)
		{
			_orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			_emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
		}

		/// <summary>
		/// Created Order
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
		{
			var orderEntity = _mapper.Map<Order>(request);

			var result = _orderRepository.GetByIdAsync(orderEntity.Id);// validation duplication order
			if (result == null)
			{
				var newOrder = await _orderRepository.AddAsync(orderEntity);// Create new order
				await SendMailCustomer(newOrder);       // Send mail wit notification to customer	
				await SendMailRestauran(newOrder);
				Guid myid = newOrder.Id;
				int id = BitConverter.ToInt32(myid.ToByteArray());
				return id;
			}
			return 0;
			
		}

		/// <summary>
		/// Send Mail to customer
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		private async Task SendMailCustomer(Order order)
		{
			var email = new Email() { To = "customermail@gmail.com", Body = $"Order was created. Order number: {order.Id}", Subject = "Order was created" };

			try
			{
				await _emailService.SendEmail(email);
			}
			catch (Exception ex)
			{
				string error = string.Format($"Order {order.Id} failed due to an error with the mail service: {ex.Message}");
			}
		}
		private async Task SendMailRestauran(Order order)
		{
			var email = new Email() { To = "restauranmail@gmail.com", Body = $"Order was created. Order number: {order.Id}, List items: {order.OrderItems} ", Subject = "Order was created" };

			try
			{
				await _emailService.SendEmail(email);
			}
			catch (Exception ex)
			{
				string error = string.Format($"Order {order.Id} failed due to an error with the mail service: {ex.Message}");
			}
		}
	}
}
