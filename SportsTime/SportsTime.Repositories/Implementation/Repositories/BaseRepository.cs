using Microsoft.EntityFrameworkCore;
using SportsTime.Data.Entities;
using SportsTime.Repositories.Inteface.IRepositories;
using System.Linq.Expressions;
namespace SportsTime.Repositories.Implementation.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
	private readonly DbSet<T> _dbSet;
	protected readonly ApplicationDbContext _dbcontext;

	public BaseRepository(ApplicationDbContext context)
	{
		_dbcontext = context;
		_dbSet = _dbcontext.Set<T>();
	}

	public async Task AddAsync(T entity)
	{
		await _dbSet.AddAsync(entity);
	}


	public void Edit(T entity)
	{
		_dbSet.Update(entity);
	}

	public async Task AddRangeAsync(IEnumerable<T> entites)
	{
		await _dbSet.AddRangeAsync(entites);
	}

	public void Dispose()
	{
		_dbcontext.Dispose();
	}

	public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filterPredicate)
	{
		return await _dbSet.Where(filterPredicate).ToListAsync();
	}

	public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filterPredicate, Expression<Func<T, dynamic>> selector)
	{
		return await _dbSet.Where(filterPredicate).Include(selector).ToListAsync();
	}

	public async Task<T> GetByIdAsync(int id)
	{
		return await _dbSet.FindAsync(id);
	}

	public async Task<List<T>> GetAllAsync(int companyId)
	{
		return await _dbSet.Where(x => !x.IsDeleted && x.CompanyId == companyId).ToListAsync();
	}

	public async Task<List<T>> GetAllAsync()
	{
		return await _dbSet.Where(x => !x.IsDeleted).ToListAsync();
	}

	public async Task<List<T>> GetAllAsyncWithoutCondition()
	{
		return await _dbSet.ToListAsync();
	}


	public void Remove(T entity)
	{
		_dbSet.Remove(entity);
	}

	public IQueryable<T> GetAllQ()
	{
		try
		{
			IQueryable<T> query = _dbcontext.Set<T>();
			return query;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public async Task Remove(int id)
	{
		var entity = await _dbSet.FindAsync(id);
		_dbSet.Remove(entity);
	}

	public void RemoveRange(IEnumerable<T> entites)
	{
		_dbSet.RemoveRange(entites);
	}

	public async Task RemoveRange(Expression<Func<T, bool>> predicate)
	{
		var entites = await _dbSet.Where(predicate).ToListAsync();
		_dbSet.RemoveRange(entites);
	}

	public async Task<int> SaveChangesAsync()
	{
		return await _dbcontext.SaveChangesAsync();
	}

	public IQueryable<T> GetAllWhereQueryable(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
	{
		return InsializeQuery(includes).Where(predicate);
	}

	public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
	{
		return await InsializeQuery(includes).FirstOrDefaultAsync(predicate);
	}

	public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
	{
		return await InsializeQuery().FirstOrDefaultAsync(predicate);
	}

	public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
	{
		return await InsializeQuery().CountAsync(predicate);
	}

	private IQueryable<T> InsializeQuery(params Expression<Func<T, object>>[] includes)
	{
		var query = _dbSet.AsQueryable();
		if (includes.Any())
		{
			foreach (var include in includes)
			{
				query = query.Include(include);
			}
		}
		return query;
	}

	public int GetExpectedNo(Func<T, int> columnSelector)
	{
		if (_dbSet.Count() == 0)
		{
			return 1;
		}
		var GetMaxId = _dbSet.Max(columnSelector);
		return GetMaxId + 1;
	}

	public int GetExpectedNo(Func<T, int> columnSelector, Expression<Func<T, bool>> predicate)
	{
		if (_dbSet.Where(predicate).Count() == 0)
		{
			return 1;
		}
		var GetMaxId = _dbSet.Where(predicate).Max(columnSelector);
		return GetMaxId + 1;
	}
}
