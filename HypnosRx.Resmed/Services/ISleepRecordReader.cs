using HypnosRx.Data.Models;

namespace HypnosRx.Resmed.Services
{
  public interface ISleepRecordReader
  {
    IList<SleepSession> Read(string filePath);
  }
}