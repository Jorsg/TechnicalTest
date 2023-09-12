using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Features.Orders.Commands.CheckoutOrde;
using Ordering.Application.Features.Orders.Queries.GetOrderList;
using System.Net;

namespace Ordering.API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private readonly IPublishEndpoint _publishEndpoint;       

		public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{userName}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrdersVm>>> GetOrderByUserName(string userName)
        {
            var query = new GetOrdersListQuery(userName);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

		[HttpGet("{RestaurantName}", Name = "GetOrderRestaurant")]
		[ProducesResponseType(typeof(IEnumerable<OrdersVm>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IEnumerable<OrdersVm>>> GetOrderByRestaurant(string RestaurantName)
		{
			var query = new GetOrderRestaurantQuery(RestaurantName);
			var orders = await _mediator.Send(query);
			return Ok(orders);
		}


		[HttpPost(Name = "CheckoutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CheckoutOrder([FromBody] CheckoutOrderCommand command)
        {
            var result = await _mediator.Send(command);
			// send checkout event to rabbitmq
			var eventMessage = _mapper.Map<NotificationCheckoutEvent>(command);			
			await _publishEndpoint.Publish(eventMessage);
			return Ok(result);
        }

    }
}
