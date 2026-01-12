using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Data.Entities.Users;

[Table("Employees", Schema = "User")]
public class Employee : BaseEntity
{
    public string Name { get; set; } = "";
    public int Code { get; set; }
    public string Job { get; set; } = "";
    public bool IsHired { get; set; }
    public int Gender { get; set; }
    public DateTime JoinDate { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal Salary { get; set; }
    public string? Email { get; set; }
    public string? Notes { get; set; }
    public string? Experience { get; set; }
    public string Address { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string? CVPath { get; set; } = "";
    public string? ImagePath { get; set; } = "";
}