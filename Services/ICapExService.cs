using Inambu_Manufacturing_Pty.Models;

namespace Inambu_Manufacturing_Pty.Services
{
  public interface ICapExService
  {
    Task<List<CapitalExRequestModel>> GetAllAsync();
    Task<CapitalExRequestModel?> GetByIdAsync(int requestId);
    Task<CapitalExRequestModel> CreateAsync(CapitalExRequestInput input, string userId);
    Task<Data.ApplicationUser?> GetUserAsync(string userId);
  }
}

