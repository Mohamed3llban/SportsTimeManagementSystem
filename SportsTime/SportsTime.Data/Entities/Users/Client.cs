using SportsTime.Data.Entities.Sports;
using SportsTime.Data.Entities.Training;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Data.Entities.Users;
[Table("Clients", Schema = "User")]
public class Client : BaseEntity
{
    public string Name { get; set; } = "";
    public string? Bio { get; set; }
    public string? Note { get; set; }
    public DateTime JoinDate { get; set; }
    public bool IsCurrentClient { get; set; }
    public string? Email { get; set; }
    public string Address { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string? WebsiteUrl { get; set; } = "";
}