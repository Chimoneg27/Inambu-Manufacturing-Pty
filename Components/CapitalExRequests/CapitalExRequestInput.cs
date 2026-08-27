using System.ComponentModel.DataAnnotations;

public class CapitalExRequestInput
{
  [Required]
  public int AmountRequested { get; set; }

  [Required]
  public string Comment { get; set; } = string.Empty;
}