
namespace HypnosRx.Data
{
  public interface IGenericRepository<TDataModel>
  {
    Task<int> CreateAsync(TDataModel model);
    Task CreateManyAsync(IEnumerable<TDataModel> models);
    Task DeleteAsync(int id);
    Task UpdateAsync(TDataModel model);
  }
}