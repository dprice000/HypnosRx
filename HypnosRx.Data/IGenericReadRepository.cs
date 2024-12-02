
namespace HypnosRx.Data
{
  public interface IGenericReadRepository<TDataModel>
  {
    string TableName { get; }

    Task<TDataModel?> GetByIdAsync(int id);
    Task<IEnumerable<TDataModel>> GetByValueAsync(string columnName, object value);
    Task<IEnumerable<TDataModel?>> GetManyAsync(IEnumerable<int> ids);
  }
}