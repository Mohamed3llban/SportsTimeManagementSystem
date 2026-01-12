using SportsTime.Data.Entities;
using SportsTime.Data.Entities.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsTime.Data.Entities.Sports;

[Table("Sports", Schema = "Sport")]
public class Sport : BaseEntity
{
	public string Name { get; set; } = "";
	public string Description { get; set; } = "";
	public decimal SubscribtionCost { get; set; }
	public int SportType { get; set; }  // Individual =>1  Team 2
    public List<Trainer> Trainers { get; set; } = new List<Trainer>();
    public List<Trainee> Trainees { get; set; } = new List<Trainee>();
    public List<Subscribtion> Subscribtions { get; set; }
    public List<Championship> Championships { get; set; } = new List<Championship>();
}