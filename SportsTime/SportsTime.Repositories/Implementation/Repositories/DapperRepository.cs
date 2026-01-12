using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SportsTime.Repositories.Inteface.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Repositories.Implementation.Repositories;

public class DapperRepository : IDapperRepository
{
	public IDbConnection dbConnection
	{
		set => InnerConnection = value;
	}

	public int commandTimeout
	{
		set => _commandTimeout = value;
	}

	private int? _commandTimeout { get; set; } = null;
	private IDbConnection InnerConnection { get; set; }
	private readonly IConfiguration _Configuration;

	public DapperRepository(IConfiguration Configuration)
	{
		_Configuration = Configuration;
		//--- default Connections
		InnerConnection = new SqlConnection(_Configuration.GetConnectionString("connectionString"));
	}

	public void Dispose()
	{
		if (InnerConnection != null && InnerConnection.State != ConnectionState.Closed)
			InnerConnection.Close();
	}

	public void OpenConnection()
	{
		if (InnerConnection.State != ConnectionState.Open && InnerConnection.State != ConnectionState.Connecting)
			InnerConnection.Open();
	}

	public List<T> Query<T>(string query, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			return InnerConnection.Query<T>(query, parameters, commandTimeout: _commandTimeout).ToList();
		}
		catch (Exception ex)
		{
			return new List<T>();
		}
	}

	public T Query<T>(string query, object parameters = null, CommandType? commandType = null)
	{
		try
		{
			this.OpenConnection();
			var data = InnerConnection.QueryFirst<T>(query, parameters, commandTimeout: _commandTimeout, commandType: commandType);
			return data;
		}
		catch (Exception ex)
		{
			return default(T);
		}
	}

	public async Task<T> QueryAsync<T>(string query, object parameters = null, CommandType? commandType = null)
	{
		try
		{
			this.OpenConnection();
			var data = await InnerConnection.QueryFirstAsync<T>(query, parameters, commandTimeout: _commandTimeout, commandType: commandType);
			return data;
		}
		catch (Exception ex)
		{
			return default(T);
		}
	}

	public async Task<List<T>> QueryAsync<T>(string query, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			var data = await (InnerConnection.QueryAsync<T>(query, parameters, commandTimeout: _commandTimeout));
			return data.ToList();
		}
		catch (Exception ex)
		{
			return new List<T>();
		}
	}

	public T QueryFirst<T>(string query, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			return InnerConnection.QueryFirst<T>(query, parameters, commandTimeout: _commandTimeout);
		}
		catch (Exception ex)
		{
			return default(T);
		}
	}

	public T QuerySingle<T>(string query, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			return InnerConnection.QuerySingle<T>(query, parameters, commandTimeout: _commandTimeout);
		}
		catch (Exception ex)
		{
			return default(T);
		}
	}

	public async Task<T> QuerySingleAsync<T>(string query, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			var data = await InnerConnection.QuerySingleAsync<T>(query, parameters, commandTimeout: _commandTimeout);
			return data;
		}
		catch (Exception ex)
		{
			return Task.FromResult(default(T)).Result;
		}
	}

	public async Task<T> QueryFirstAsync<T>(string query, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			var data = await InnerConnection.QueryFirstAsync<T>(query, parameters, commandTimeout: _commandTimeout);
			return data;
		}
		catch (Exception ex)
		{
			return Task.FromResult(default(T)).Result;
		}
	}

	public T QueryFirstOrDefault<T>(string query, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			return InnerConnection.QueryFirstOrDefault<T>(query, parameters, commandTimeout: _commandTimeout);
		}
		catch (Exception ex)
		{
			return default(T);
		}
	}

	public async Task<T> QueryFirstOrDefaultAsync<T>(string query, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			var data = await InnerConnection.QueryFirstOrDefaultAsync<T>(query, parameters, commandTimeout: _commandTimeout);
			return data;
		}
		catch (Exception ex)
		{
			return Task.FromResult(default(T)).Result;
		}
	}

	public T QuerySingleOrDefault<T>(string query, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			return InnerConnection.QuerySingleOrDefault<T>(query, parameters, commandTimeout: _commandTimeout);
		}
		catch (Exception ex)
		{
			return default(T);
		}
	}

	public async Task<T> QuerySingleOrDefaultAsync<T>(string query, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			var data = await InnerConnection.QuerySingleOrDefaultAsync<T>(query, parameters, commandTimeout: _commandTimeout);
			return data;
		}
		catch (Exception ex)
		{
			return Task.FromResult(default(T)).Result;
		}
	}

	public int Execute(string sql, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			var data = InnerConnection.Execute(sql, parameters, commandTimeout: _commandTimeout, commandType: CommandType.Text);
			return data;
		}
		catch (Exception ex)
		{
			return Task.FromResult(default(int)).Result;
		}
	}

	public async Task<int> ExecutAsync<T>(string sql, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			var data = await InnerConnection.ExecuteAsync(sql, parameters, commandTimeout: _commandTimeout, commandType: CommandType.Text);
			return data;
		}
		catch (Exception ex)
		{
			return Task.FromResult(default(int)).Result;
		}
	}

	public List<T> ExecutProcedure<T>(string procedureName, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			var data = InnerConnection.Query<T>(procedureName, parameters, commandTimeout: _commandTimeout, commandType: CommandType.StoredProcedure);
			return data.ToList();
		}
		catch (Exception ex)
		{
			return new List<T>();
		}
	}

	public async Task<List<T>> ExecutProcedureAsync<T>(string procedureName, object parameters = null)
	{
		try
		{
			//  this.OpenConnection();
			var data = await InnerConnection.QueryAsync<T>(procedureName, parameters, commandTimeout: _commandTimeout, commandType: CommandType.StoredProcedure);
			return data.ToList();
		}
		catch (Exception ex)
		{
			return new List<T>();
		}
	}

	public object ExecuteScalar(string sql, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			var data = InnerConnection.ExecuteScalar(sql, parameters, commandTimeout: _commandTimeout);
			return data;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public async Task<object> ExecuteScalarAsync(string sql, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			var data = await InnerConnection.ExecuteScalarAsync(sql, parameters, commandTimeout: _commandTimeout);
			return data;
		}
		catch (Exception ex)
		{
			return null;
		}
	}

	public T ExecuteScalar<T>(string sql, object parameters = null)
	{
		throw new NotImplementedException();
	}

	public async Task<T> ExecuteScalarAsync<T>(string sql, object parameters = null)
	{
		try
		{
			this.OpenConnection();
			var data = await InnerConnection.ExecuteScalarAsync<T>(sql, parameters, commandTimeout: _commandTimeout);
			return data;
		}
		catch (Exception ex)
		{
			return Task.FromResult(default(T)).Result;
		}
	}
}
