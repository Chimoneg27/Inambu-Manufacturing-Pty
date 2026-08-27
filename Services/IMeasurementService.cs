using Inambu_Manufacturing_Pty.Models;


namespace Inambu_Manufacturing_Pty.Services
{
  // the shape of our measurement service
  public interface IMeasurementService
  {
    Task<List<ProductionLine>> GetProductionLinesAsync(); // getting a list/array of production lines
    Task<List<MeasurementInputModel>> GetMeasurementsAsync(); // getting the array of measurements
    Task AddMeasurementAsync(MeasurementInputModel input, string userId); // when we add our measurement
    Task<bool> DeleteMeasurementAsync(int id, string userId); // removing the measurement capture
    Dictionary<string, MeasurementStatistics> CalculateStatistics(List<MeasurementInputModel> measurements);
  }
}
