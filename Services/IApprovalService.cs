using Inambu_Manufacturing_Pty.Models;

namespace Inambu_Manufacturing_Pty.Services
{
public interface IApprovalService
{
    Task<List<ApprovalHistoryModel>> GetHistoryAsync(int requestId);
    Task ApproveAsync(int requestId, string currentUserId);
    Task RejectAsync(int requestId, string currentUserId);
}
}