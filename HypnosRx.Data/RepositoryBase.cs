namespace HypnosRx.Data
{
  public abstract class RepositoryBase
  {
    protected string _connectionString { get; }

    public RepositoryBase(string connectionString)
    {
      _connectionString = connectionString;
    }
  }
}
