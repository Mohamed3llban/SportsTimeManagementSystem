using SportsTime.Data.Entities;
using SportsTime.Data.Entities.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsTime.Data.Entities.Sports;

[Table("Championships", Schema = "Sport")]
public class Championship : BaseEntity
{
	public string Name { get; set; } = "";
	public string Location { get; set; } = "";
	public DateTime ChampDate { get; set; }
	public decimal CostPerTrainee { get; set; }
	public bool IsIndividual { get; set; }
    public int Type { get; set; }
    public int SportId { get; set; }
	[ForeignKey(nameof(SportId))]
	public Sport Sport { get; set; } = new Sport();

	public int TrainerId { get; set; }
	[ForeignKey(nameof(TrainerId))]
	public Trainer Trainer { get; set; } = new Trainer();

	public string TraineesIds { get; set; } = ""; /*"1,2,3,4"*/
}