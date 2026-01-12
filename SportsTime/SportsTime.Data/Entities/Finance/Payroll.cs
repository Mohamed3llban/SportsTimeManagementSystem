using SportsTime.Data.Entities.Sports;
using SportsTime.Data.Entities.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Data.Entities.Finance;

[Table("Payrolls", Schema = "Finance")]
public class Payroll : BaseEntity
{
    public int EmployeeId { get; set; }
    public bool IsTrainer { get; set; }
    public decimal SalaryAmount { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime LastPaymentDate { get; set; }

    [ForeignKey(nameof(EmployeeId))]
    public Trainer Trainer { get; set; } = new Trainer();
}
