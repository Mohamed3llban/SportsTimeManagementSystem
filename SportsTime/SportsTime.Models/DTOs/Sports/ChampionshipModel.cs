using SportsTime.Models.DTOs.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Models.DTOs.Sports;

public class ChampionshipModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public string Name { get; set; } = ""; 
    [Required(ErrorMessage = "RequiredField")]
    public string Location { get; set; } = "";
    [Required(ErrorMessage = "RequiredField")]
    public DateTime ChampDate { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public decimal CostPerTrainee { get; set; }
    public bool IsIndividual { get; set; }
    public int Type { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public int SportId { get; set; }
    public string? SportName  { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public int TrainerId { get; set; }
    public string? TrainerName { get; set; }
    public int? TraineesCount { get; set; } = 0;

    public string? TraineesIds { get; set; }

    public List<DropDownModel>? Trainees { get; set; }
}