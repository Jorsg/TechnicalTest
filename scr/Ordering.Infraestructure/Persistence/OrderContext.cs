using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entity;

namespace Ordering.Infraestructure.Persistence
{
	public class OrderContext : DbContext
	{
		public OrderContext(DbContextOptions<OrderContext> options) : base(options)
		{
		}

		public DbSet<Order> Orders { get; set; }
	}
}
