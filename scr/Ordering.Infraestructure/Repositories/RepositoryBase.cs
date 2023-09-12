using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Common;
using Ordering.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infraestructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
	{
		protected readonly OrderContext _dbContex;
		public RepositoryBase(OrderContext dbContex)
		{
			_dbContex = dbContex ?? throw new ArgumentNullException(nameof(dbContex));
		}

		public async Task<T> AddAsync(T entity)
		{
			_dbContex.Set<T>().Add(entity);
			await _dbContex.SaveChangesAsync();
			return entity;
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			return await _dbContex.Set<T>().FindAsync(id);
		}
	}
}
