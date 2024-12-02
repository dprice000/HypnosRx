using Dapper;
using Microsoft.Data.Sqlite;

namespace HypnosRx.Data
{
  public class GenericRepository<TDataModel> : GenericReadRepository<TDataModel>, IGenericReadRepository<TDataModel>, IGenericRepository<TDataModel>
  {
    public GenericRepository(string connectionString, string tableName) : base(connectionString, tableName) { }

    public async Task<int> CreateAsync(TDataModel model)
    {
      var propertyNames = typeof(TDataModel).GetProperties()
                                      .Select(prop => prop.Name)
                                      .Where(name => !name.Equals("RowId", StringComparison.InvariantCultureIgnoreCase));


      var query = $@"INSERT INTO [{TableName}] ({string.Join(",", propertyNames)})
 VALUES ({string.Join(",", propertyNames.Select(name => $"@{name}"))});
SELECT last_insert_rowid();";

      using (SqliteConnection conn = new SqliteConnection(_connectionString))
      {
        return await conn.ExecuteScalarAsync<int>(query, model);
      }
    }

    public async Task CreateManyAsync(IEnumerable<TDataModel> models)
    {
      var properties = typeof(TDataModel).GetProperties()
                                      .Where(prop => !prop.Name.Equals("RowId", StringComparison.InvariantCultureIgnoreCase));


      var query = $@"INSERT INTO [{TableName}] ({string.Join(",", properties.Select(prop => prop.Name))})
 VALUES ";

      query += $"({string.Join(",", string.Join(",", properties.Select(prop => $"@{prop.Name}")))})";

      using (SqliteConnection conn = new SqliteConnection(_connectionString))
      {
        await conn.ExecuteAsync(query, models);
      }
    }

    public async Task UpdateAsync(TDataModel model)
    {
      var propertyNames = typeof(TDataModel).GetProperties()
                                          .Select(prop => prop.Name)
                                         .Where(name => !name.Equals("RowId", StringComparison.InvariantCultureIgnoreCase));

      var query = $@"UPDATE [{TableName}] 
 SET {string.Join(", ", propertyNames.Select(name => $"[{name}] = @{name}"))}
 WHERE [Id] = @Id";

      using (SqliteConnection conn = new SqliteConnection(_connectionString))
      {
        await conn.ExecuteAsync(query, model);
      }
    }

    public async Task DeleteAsync(int rowId)
    {
      using (SqliteConnection conn = new SqliteConnection(_connectionString))
      {
        await conn.ExecuteAsync($"DELETE FROM [{TableName}] WHERE [RowId] = @rowId", rowId);
      }
    }
  }
}
