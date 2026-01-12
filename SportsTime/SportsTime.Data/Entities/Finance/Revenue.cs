using SportsTime.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Data.Entities.Finance;
[Table("Revenues", Schema = "Finance")]

public class Revenue : BaseEntity
{
	public string Note { get; set; } = "";
	public decimal Amount { get; set; }
	public int RecordId { get; set; }
	public int RecordScreenCode { get; set; }
 }