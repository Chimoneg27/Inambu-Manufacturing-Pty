using Inambu_Manufacturing_Pty.Models;

public static class ApprovalTierHelper
{
  public static List<string> GetApprovalChain(decimal amount)
  {
    if (amount >= 5000 && amount <= 24999)
      return new List<string> { "DepartmentManager" };
    else if (amount >= 25000 && amount <= 99999)
      return new List<string> { "DepartmentManager", "FinanceDirector" };
    else if (amount >= 100000)
            return new List<string> { "DepartmentManager", "FinanceDirector", "CEO" };
    else return new List<string>();
  }

  public static ApprovalStage GetNextStage(ApprovalStage current, decimal amount)
  {
    var approvalChain = GetApprovalChain(amount); // returns a list of the people needed to approve the expenses
    var currentRole = current.ToString(); // we check who is the current approver 

    int index = approvalChain.IndexOf(currentRole); // checks the position of the approver in the list

    if (index == -1 || index == approvalChain.Count - 1)
      return ApprovalStage.Finalised;

    var nextRole = approvalChain[index + 1];
    return Enum.Parse<ApprovalStage>(nextRole);
  }
}