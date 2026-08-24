using Inambu_Manufacturing_Pty.Data;

namespace Inambu_Manufacturing_Pty.Models;

public class Measurement
{
  public int Id { get; set; }
  public decimal Temperature { get; set; }
  public decimal Humidity { get; set; }
  public decimal Weight { get; set; }
  public decimal Width { get; set; }
  public decimal Length { get; set; }
  public decimal Depth { get; set; }
  public bool Passed { get; set; }
  public DateTime CapturedAtUtc { get; set; }

  public int ProductionLineId { get; set; }
  public ProductionLine ProductionLine { get; set; } = null!; 

  public string ApplicationUserId { get; set; } = null!;
  public ApplicationUser ApplicationUser { get; set; } = null!;
}