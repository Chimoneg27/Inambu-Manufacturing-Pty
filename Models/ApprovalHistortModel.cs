using Inambu_Manufacturing_Pty.Data;

namespace Inambu_Manufacturing_Pty.Models;

public enum ApprovalChoices { Approved, Rejected }

public class ApprovalHistoryModel
{
  public int Id { get; set; }

  public int CapitalExId { get; set; }
  public CapitalExRequestModel? CapitalExRequest { get; set; }

  public string ActionByUserId { get; set; } = string.Empty;
  public ApplicationUser? ActionByUser { get; set; }

  public ApprovalChoices Action { get; set; }
  public string? Comment { get; set; }
  public DateTime ApprovedOrRejectedAt { get; set; } = DateTime.UtcNow;
}