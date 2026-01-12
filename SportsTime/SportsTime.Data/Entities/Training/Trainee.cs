using SportsTime.Data.Entities;
using SportsTime.Data.Entities.Sports;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsTime.Data.Entities.Training;

[Table("Trainees", Schema = "Training")]
public class Trainee : BaseEntity
{
	public string Name { get; set; } = "";
	public int Code { get; set; }
	public int Status { get; set; }
	public int Gender { get; set; }
	public int SportId { get; set; }
	public int TrainerId { get; set; }
	public int DepartmentId { get; set; }
	public string? Email { get; set; }
	public string? Notes { get; set; }
	public string Address { get; set; } = "";
	public string PhoneNumber { get; set; } = "";
	public DateTime JoinDate { get; set; }
	public DateTime DateOfBirth { get; set; }
	public string? ImagePath { get; set; } = "";

    [ForeignKey(nameof(SportId))]
    public Sport Sport { get; set; } = new Sport();

    [ForeignKey(nameof(TrainerId))]
    public Trainer Trainer { get; set; } = new Trainer();

    public List<Subscribtion>? Subscribtions { get; set; }
    public List<Championship>? Championships { get; set; }

	//[ForeignKey(nameof(DepartmentId))]
	//public Department Department { get; set; } = new Department();
	
}
