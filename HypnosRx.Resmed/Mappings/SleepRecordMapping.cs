using CsvHelper.Configuration;
using HypnosRx.Data.Models;

namespace HypnosRx.Resmed.Mappings
{
  public sealed class SleepRecordMapping : ClassMap<SleepSession>
  {
    public SleepRecordMapping() 
    {
      Map(m => m.Ahi).Name("AHI");
      Map(m => m.PatientId).Name("PATIENT_ID");
      Map(m => m.SessionDate).Name("SESSION_DATE");
      Map(m => m.UsageHours).Name("USAGE_HOURS");
      Map(m => m.MaskSessionCount).Name("MASK_SESSION_COUNT");
      Map(m => m.LeakScore).Name("LEAK_SCORE");
      Map(m => m.Source).Name("SOURCE");
    } 
  }
}
