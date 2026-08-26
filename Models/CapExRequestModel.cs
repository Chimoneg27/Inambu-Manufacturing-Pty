using Inambu_Manufacturing_Pty.Data;

namespace Inambu_Manufacturing_Pty.Models;

public enum CapExStatus { Pending, Approved, Rejected }
public enum ApprovalStage { DepartmentManager, FinanceDirector, CEO, Finalised }

public class CapitalExRequestModel
{
  public int Id { get; set; }
  public decimal Amount { get; set; }
  public string Description { get; set; } = string.Empty;

  public string RequestedByUserId { get; set; } = string.Empty;
  public ApplicationUser? RequestedByUser { get; set; }

  public CapExStatus Status { get; set; } = CapExStatus.Pending;
  public ApprovalStage CurrentStage { get; set; } = ApprovalStage.DepartmentManager;
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public ICollection<ApprovalHistoryModel> History { get; set; } = new List<ApprovalHistoryModel>();
}