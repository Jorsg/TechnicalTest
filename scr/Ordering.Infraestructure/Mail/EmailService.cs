using Ordering.Application.Contracts.Infraestructure;
using Ordering.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infraestructure.Mail
{
	public class EmailService : IEmailService
	{


		public Task<bool> SendEmail(Email email)
		{
			//Logic Send the Mail;
			return Task.FromResult(true);
		}
	}
}
