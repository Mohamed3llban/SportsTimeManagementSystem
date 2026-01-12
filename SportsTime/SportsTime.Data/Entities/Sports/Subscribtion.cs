using SportsTime.Data.Entities.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Data.Entities.Sports;

[Table("Subscribtions", Schema = "Sports")]
public class Subscribtion : BaseEntity
{
    public int TraineeId { get; set; }
    public int TrainerId { get; set; }
    public int SportId { get; set; }
    public decimal SubscribtionCost { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }

    [ForeignKey(nameof(SportId))]
    public Sport Sport { get; set; } = new Sport();
    [ForeignKey(nameof(TrainerId))]
    public Trainer Trainer { get; set; } = new Trainer();
    [ForeignKey(nameof(TraineeId))]
    public Trainee Trainee { get; set; } = new Trainee();
}