using Inambu_Manufacturing_Pty.Data;
using Inambu_Manufacturing_Pty.Models;
using Microsoft.EntityFrameworkCore;

namespace Inambu_Manufacturing_Pty.Services
{
  public class ApprovalService : IApprovalService
  {
    private readonly ApplicationDbContext _dbContext = null!;

    public ApprovalService(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<List<ApprovalHistoryModel>> GetHistoryAsync(int requestId)
    {
      return await _dbContext.ApprovalHistoryModels
          .Include(hist => hist.ActionByUser)
          .Where(hist => hist.CapitalExId == requestId)
          .OrderBy(hist => hist.ApprovedOrRejectedAt)
          .ToListAsync();
    }

    public async Task ApproveAsync(int requestId, string currentUserId)
    {
      var req = await _dbContext.CapitalExRequestModels.FindAsync(requestId);
      if (req == null) return;

      var action = new ApprovalHistoryModel
      {
        CapitalExId = requestId,
        ActionByUserId = currentUserId,
        Action = ApprovalChoices.Approved,
        ApprovedOrRejectedAt = DateTime.UtcNow
      };

      _dbContext.ApprovalHistoryModels.Add(action);

      var nextStage = ApprovalTierHelper.GetNextStage(req.CurrentStage, req.Amount);

      if (nextStage == ApprovalStage.Finalised)
      {
        req.Status = CapExStatus.Approved;
      }
      else
      {
        req.CurrentStage = nextStage;
      }

      await _dbContext.SaveChangesAsync();
    }

    public async Task RejectAsync(int requestId, string currentUserId)
    {
      var request = await _dbContext.CapitalExRequestModels.FindAsync(requestId);
      if (request == null) return;

      var action = new ApprovalHistoryModel
      {
        CapitalExId = requestId,
        ActionByUserId = currentUserId,
        Action = ApprovalChoices.Rejected,
        ApprovedOrRejectedAt = DateTime.UtcNow
      };

      _dbContext.ApprovalHistoryModels.Add(action);
      request.Status = CapExStatus.Rejected;

      await _dbContext.SaveChangesAsync();
    }
  }
}