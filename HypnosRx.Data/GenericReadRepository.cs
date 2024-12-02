using Dapper;
using Microsoft.Data.Sqlite;

namespace HypnosRx.Data
{
  public class GenericReadRepository<TDataModel> : RepositoryBase, IGenericReadRepository<TDataModel>
  {
    public string TableName { get; }

    public GenericReadRepository(string connectionString, string tableName) : base(connectionString)
    {
      TableName = tableName;
    }

    public async Task<TDataModel?> GetByIdAsync(int id)
    {
      using (SqliteConnection conn = new SqliteConnection(_connectionString))
      {
        return await conn.QueryFirstOrDefaultAsync<TDataModel>($"SELECT * FROM [{TableName}] WHERE Id = @Id", new { Id = id });
      }
    }

    public async Task<IEnumerable<TDataModel>> GetByValueAsync(string columnName, object value)
    {
      using (SqliteConnection conn = new SqliteConnection(_connectionString))
      {
        return await conn.QueryAsync<TDataModel>($"SELECT * FROM [{TableName}] WHERE [{columnName}] = @Value", new { Value = value });
      }
    }

    public async Task<IEnumerable<TDataModel?>> GetManyAsync(IEnumerable<int> ids)
    {
      using (SqliteConnection conn = new SqliteConnection(_connectionString))
      {
        var query = $"SELECT * FROM [{TableName}] WHERE Id IN ({string.Join(",", ids)})";

        return await conn.QueryAsync<TDataModel>(query);
      }
    }
  }
}
