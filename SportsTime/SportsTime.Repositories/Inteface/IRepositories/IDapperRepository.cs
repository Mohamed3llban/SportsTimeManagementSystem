using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Repositories.Inteface.IRepositories;

public interface IDapperRepository : IDisposable
{
	void OpenConnection();
	int commandTimeout { set; }
	IDbConnection dbConnection { set; }
	List<T> Query<T>(string query, object parameters = null);
	T Query<T>(string query, object parameters = null, CommandType? commandType = null);
	Task<T> QueryAsync<T>(string query, object parameters = null, CommandType? commandType = null);
	Task<List<T>> QueryAsync<T>(string query, object parameters = null);
	T QuerySingle<T>(string query, object parameters = null);
	Task<T> QuerySingleAsync<T>(string query, object parameters = null);
	T QueryFirst<T>(string query, object parameters = null);
	Task<T> QueryFirstAsync<T>(string query, object parameters = null);
	T QueryFirstOrDefault<T>(string query, object parameters = null);
	Task<T> QueryFirstOrDefaultAsync<T>(string query, object parameters = null);
	T QuerySingleOrDefault<T>(string query, object parameters = null);
	Task<T> QuerySingleOrDefaultAsync<T>(string query, object parameters = null);
	int Execute(string sql, object parameters = null);
	Task<int> ExecutAsync<T>(string sql, object parameters = null);
	List<T> ExecutProcedure<T>(string procedureName, object parameters = null);
	Task<List<T>> ExecutProcedureAsync<T>(string procedureName, object parameters = null);
	object ExecuteScalar(string sql, object parameters = null);
	Task<object> ExecuteScalarAsync(string sql, object parameters = null);
	T ExecuteScalar<T>(string sql, object parameters = null);
	Task<T> ExecuteScalarAsync<T>(string sql, object parameters = null);
}
