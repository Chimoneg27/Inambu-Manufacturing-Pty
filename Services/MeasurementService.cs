using Inambu_Manufacturing_Pty.Data;
using Inambu_Manufacturing_Pty.Models;
using Microsoft.EntityFrameworkCore;

namespace Inambu_Manufacturing_Pty.Services
{
  public class MeasurementService : IMeasurementService
  {
    private readonly ApplicationDbContext _dbContext = null!; // get our projects db context. this is the orm

    public MeasurementService(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<List<ProductionLine>> GetProductionLinesAsync()
    {
      return await _dbContext.ProductionLines.ToListAsync();
    }

    public async Task<List<MeasurementInputModel>> GetMeasurementsAsync()
    {
      return await _dbContext.Measurements
                  .Include(m => m.ApplicationUser) // we have to pull the user and the production lines as well
                  .Include(m => m.ProductionLine)
                  .OrderByDescending(m => m.CapturedAtUtc)
                  .ToListAsync();
    }

    public async Task AddMeasurementAsync(MeasurementInputModel input, string userId)
    {
      input.CapturedAtUtc = DateTime.UtcNow;
      input.ApplicationUserId = userId;

      _dbContext.Measurements.Add(input);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteMeasurementAsync(int id, string userId)
    {
      var capture = await _dbContext.Measurements
        .Include(measurement => measurement.ApplicationUser)
        .FirstOrDefaultAsync(measurement => measurement.Id == id);

      if (capture is null)
      {
        return false;
      }

      if (capture.ApplicationUserId != userId)
      {
        return false;
      }

      _dbContext.Measurements.Remove(capture);
      await _dbContext.SaveChangesAsync();
      return true;
    }

    public Dictionary<string, MeasurementStatistics> CalculateStatistics(List<MeasurementInputModel> measurements)
    {
      var statisitics = new Dictionary<string, MeasurementStatistics>();

      statisitics["Temperature"] = CalculateStats(measurements.Select(m => m.Temperature));
      statisitics["Humidity"] = CalculateStats(measurements.Select(m => m.Humidity));
      statisitics["Weight"] = CalculateStats(measurements.Select(m => m.Weight));
      statisitics["Width"] = CalculateStats(measurements.Select(m => m.Width));
      statisitics["Length"] = CalculateStats(measurements.Select(m => m.Length));
      statisitics["Depth"] = CalculateStats(measurements.Select(m => m.Depth));

      return statisitics;
    }

    // just a the helper function from the home.razor file
    private MeasurementStatistics CalculateStats(IEnumerable<decimal> values)
    {
      var numbers = values.ToList();

      if (numbers.Count == 0)
      {
        return new MeasurementStatistics();
      }

      var sum = numbers.Sum();
      var mean = sum / numbers.Count();
      var variance = numbers.Sum(n => (n - mean) * (n - mean)) / numbers.Count;
      var standardDeviation = (decimal)Math.Sqrt((double)variance);

      return new MeasurementStatistics
      {
        Highest = numbers.Max(),
        Lowest = numbers.Min(),
        Variance = variance,
        Mean = mean,
        Sum = sum,
        StandardDeviation = standardDeviation
      };
    }
  }
}
