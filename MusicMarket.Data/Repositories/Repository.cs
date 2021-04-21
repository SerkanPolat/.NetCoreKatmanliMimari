using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicMarket.Data.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly DbContext _context;
		public Repository(MusicMarketDbContext context)
		{
			_context = context;
		}
		public Task AddRanceSync(IEnumerable<TEntity> entities)
		{
			throw new NotImplementedException();
		}

		public async Task AddSync(TEntity entity)
		{
			await _context.Set<TEntity>().AddAsync(entity);
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return _context.Set<TEntity>().Where(predicate);
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

		public ValueTask<TEntity> GetByIdAsync(int id)
		{
			return _context.Set<TEntity>().FindAsync(id);
		}

		public void Remove(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_context.Set<TEntity>().RemoveRange(entities);
		}

		public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
		}
	}
}
