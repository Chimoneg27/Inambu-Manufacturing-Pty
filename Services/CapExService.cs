using Inambu_Manufacturing_Pty.Data;
using Inambu_Manufacturing_Pty.Models;
using Microsoft.EntityFrameworkCore;

namespace Inambu_Manufacturing_Pty.Services
{
  public class CapExService : ICapExService
  {
    private readonly ApplicationDbContext _dbContext = null!;

    public CapExService(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<List<CapitalExRequestModel>> GetAllAsync()
    {
      return await _dbContext.CapitalExRequestModels
                    .Include(req => req.RequestedByUser)
                    .OrderByDescending(req => req.CreatedAt)
                    .ToListAsync();
    }

    public async Task<CapitalExRequestModel?> GetByIdAsync(int requestId)
    {
      return await _dbContext.CapitalExRequestModels
            .Include(req => req.RequestedByUser)
            .FirstOrDefaultAsync(req => req.Id == requestId);
    }

    public async Task<CapitalExRequestModel> CreateAsync(CapitalExRequestInput input, string userId)
    {
      var capitalRequest = new CapitalExRequestModel
      {
        Amount = input.AmountRequested,
        Description = input.Comment,
        RequestedByUserId = userId,
        Status = CapExStatus.Pending,
        CurrentStage = ApprovalStage.DepartmentManager
      };

      _dbContext.CapitalExRequestModels.Add(capitalRequest);
      await _dbContext.SaveChangesAsync();
      return capitalRequest;
    }

    public async Task<ApplicationUser?> GetUserAsync(string userId)
    {
      return await _dbContext.Users.FindAsync(userId);
    }
  }
}