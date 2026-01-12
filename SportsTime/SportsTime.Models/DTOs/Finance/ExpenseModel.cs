using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Models.DTOs.Finance;

public class ExpenseModel
{
    public int Id { get; set; }
    public string Note { get; set; } = "";
    [Required(ErrorMessage = "RequiredField")]
    public decimal Amount { get; set; }
    public int RecordId { get; set; }
    public int RecordScreenCode { get; set; }
}