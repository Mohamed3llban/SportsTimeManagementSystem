using SportsTime.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsTime.Data.Entities.Finance;
[Table("Expenses", Schema = "Finance")]

public class Expense : BaseEntity
{
    public string Note { get; set; } = "";
    public decimal Amount { get; set; }
    public int RecordId { get; set; }
    public int RecordScreenCode { get; set; }
}