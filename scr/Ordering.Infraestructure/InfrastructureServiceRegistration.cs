using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Ordering.Infraestructure.Mail;
using Ordering.Infraestructure.Persistence;
using Ordering.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infraestructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfraestructureService(this IServiceCollection services, IConfiguration configuration)
		{
			//Configure all services about layer Infraestruture
			//Connection by DB
			//Setting Email
			//DependencyInjection Repository Order
			return services;
		}
	}
}
