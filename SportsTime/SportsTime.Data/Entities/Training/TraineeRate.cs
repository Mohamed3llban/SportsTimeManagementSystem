using SportsTime.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsTime.Data.Entities.Training;
[Table("TraineeRates", Schema = "Training")]

public class TraineeRate : BaseEntity
{
	public int Rate { get; set; }
	public int TraineeId { get; set; }
}