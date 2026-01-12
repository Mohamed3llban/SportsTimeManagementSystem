using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Models.DTOs.Sports;

public class SubscribtionModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public int TraineeId { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public int TrainerId { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public int SportId { get; set; }
    
    public string? SportName { get; set; } = "";
    public string? TraineeName { get; set; } = "";
    public string? TrainerName { get; set; } = "";

    [Required(ErrorMessage = "RequiredField")]
    public decimal SubscribtionCost { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public DateTime StartingDate { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public DateTime EndingDate { get; set; }
}