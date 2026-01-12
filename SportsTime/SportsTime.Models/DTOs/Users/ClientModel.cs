using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Models.DTOs.Users;

public class ClientModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public string Name { get; set; } = "";
    public string? Bio { get; set; }
    public string? Note { get; set; }
    public DateTime JoinDate { get; set; }
    public bool IsCurrentClient { get; set; }
    public string? Email { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public string Address { get; set; } = "";
    [Required(ErrorMessage = "RequiredField")]
    public string PhoneNumber { get; set; } = "";
    public string? WebsiteUrl { get; set; } = "";
}