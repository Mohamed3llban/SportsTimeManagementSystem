using SportsTime.Data.Entities;
using SportsTime.Data.Entities.Sports;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsTime.Data.Entities.Training;

[Table("Trainers", Schema = "Training")]
public class Trainer : BaseEntity
{
    public string Name { get; set; } = "";
    public int Code { get; set; }
    public int Status { get; set; }
    public int Gender { get; set; }
    public DateTime JoinDate { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int SportId { get; set; }
    public bool IsHired { get; set; }
    public decimal Salary { get; set; }
    public string? Email { get; set; }
    public string? Notes { get; set; }
    public string? Experience { get; set; }
    public string Address { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string? CVPath { get; set; } = "";
    public string? ImagePath { get; set; } = "";
    public List<Trainee> Trainees { get; set; } = new List<Trainee>();

    [ForeignKey(nameof(SportId))]
    public Sport Sport { get; set; } = new Sport();

    public List<Subscribtion>? Subscribtions { get; set; }
}