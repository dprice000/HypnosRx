using CsvHelper;
using HypnosRx.Data.Models;
using HypnosRx.Resmed.Mappings;
using System.Globalization;

namespace HypnosRx.Resmed.Services
{
  public class SleepRecordReader : ISleepRecordReader
  {
    public IList<SleepSession> Read(string filePath)
    {
      if (string.IsNullOrWhiteSpace(filePath))
      {
        return Enumerable.Empty<SleepSession>().ToList();
      }

      using (var reader = new StreamReader(filePath))
      using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
      {
        csv.Context.RegisterClassMap<SleepRecordMapping>();
        return csv.GetRecords<SleepSession>().ToList();
      }
    }
  }
}
