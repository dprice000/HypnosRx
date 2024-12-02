namespace HypnosRx.Data.Models
{
  public class SleepSession : ModelBase
  {
    public string PatientId { get; set; } = string.Empty;
    public DateTime SessionDate { get; set; }
    public decimal Ahi { get; set; }
    public decimal UsageHours { get; set; }
    public int MaskSessionCount { get; set; }
    public int LeakScore { get; set; }
    public string Source { get; set; } = string.Empty;
  }
}
