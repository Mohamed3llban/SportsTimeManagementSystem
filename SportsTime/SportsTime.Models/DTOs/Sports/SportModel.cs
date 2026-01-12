using SportsTime.Models.DTOs.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Models.DTOs.Sports;

public class SportModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public string Name { get; set; } = "";
    public string? Description { get; set; } = "";
    [Required(ErrorMessage = "RequiredField")]
    public decimal SubscribtionCost { get; set; }
    public int SportType { get; set; }
    public int? CreatedBy { get; set; } = 0;
    public int? CompanyId { get; set; } = 0;
    public int? ModifiedBy { get; set; } = 0;
    public DateTime? CreationDate { get; set; } = new DateTime();
    public DateTime? ModifiedDate { get; set; } = new DateTime();
    public int? TrainersCount { get; set; } = 0;
    public int? TraineesCount { get; set; } = 0;
    public List<TrainerModel> Trainers { get; set; } = new List<TrainerModel>();
    public List<TraineeModel> Trainees { get; set; } = new List<TraineeModel>();
}
