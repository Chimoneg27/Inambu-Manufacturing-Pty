namespace Inambu_Manufacturing_Pty.Models;

public class MeasurementStatistics
{
    public decimal Highest { get; set; }
    public decimal Lowest { get; set; }
    public decimal Variance { get; set; }
    public decimal Mean { get; set; }
    public decimal Sum { get; set; }
    public decimal StandardDeviation { get; set; }
}