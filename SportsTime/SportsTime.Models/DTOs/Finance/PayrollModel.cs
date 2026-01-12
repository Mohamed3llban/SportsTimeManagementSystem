using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Models.DTOs.Finance;

public class PayrollModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public int EmployeeId { get; set; }
    public bool IsTrainer { get; set; }
    public string? EmployeeName { get; set; } = "";
    [Required(ErrorMessage = "RequiredField")]
    public decimal SalaryAmount { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public DateTime DueDate { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public DateTime LastPaymentDate { get; set; }
}
