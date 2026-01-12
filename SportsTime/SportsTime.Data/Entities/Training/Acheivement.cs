using SportsTime.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsTime.Data.Entities.Training;
[Table("Achievements", Schema = "Training")]

public class Achievement : BaseEntity
{
	public string Name { get; set; } = "";
	public int WinnerId { get; set; }
	public DateTime AcheivingDate { get; set; }

	//public int SportId { get; set; }
	//[ForeignKey(nameof(SportId))]
	//public Sport Sport { get; set; }
}