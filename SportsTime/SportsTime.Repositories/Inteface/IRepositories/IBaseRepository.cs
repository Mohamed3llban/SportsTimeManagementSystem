using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace SportsTime.Repositories.Inteface.IRepositories;

public interface IBaseRepository<T>
{
	Task AddAsync(T entity);
	Task AddRangeAsync(IEnumerable<T> entites);
	void Edit(T entity);
	void Remove(T entity);
	Task Remove(int id);
	void RemoveRange(IEnumerable<T> entites);
	Task RemoveRange(Expression<Func<T, bool>> predicate);
	Task<T> GetByIdAsync(int id);
	Task<List<T>> GetAllAsync(int companyId);
	Task<List<T>> GetAllAsync();
	Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filterPredicate);
	Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filterPredicate, Expression<Func<T, dynamic>> selector);
	IQueryable<T> GetAllWhereQueryable(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
	Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
	int GetExpectedNo(Func<T, int> columnSelector);
	int GetExpectedNo(Func<T, int> columnSelector, Expression<Func<T, bool>> predicate);
	Task<int> SaveChangesAsync();
	Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
	Task<List<T>> GetAllAsyncWithoutCondition();
	Task<int> CountAsync(Expression<Func<T, bool>> predicate);
	IQueryable<T> GetAllQ();
}
