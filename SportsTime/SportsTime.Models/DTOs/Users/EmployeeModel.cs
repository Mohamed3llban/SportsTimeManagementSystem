using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Models.DTOs.Users;

public class EmployeeModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public string Name { get; set; } = "";
    [Required(ErrorMessage = "RequiredField")]
    public int Code { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public string Job { get; set; } = "";
    [Required(ErrorMessage = "RequiredField")]
    public decimal Salary { get; set; }
    public bool IsTrainer { get; set; }
    public bool IsHired { get; set; }
    public int Gender { get; set; }
    public DateTime JoinDate { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; } = "";
    [Required(ErrorMessage = "RequiredField")]
    public string PhoneNumber { get; set; } = "";
    public string? Email { get; set; }
    
    public string? Notes { get; set; }
    public string? Experience { get; set; }
    public string? ImagePath { get; set; } = "";
    public IFormFile? ImageFile { get; set; }
    public string? CVPath { get; set; } = "";
    public IFormFile? CVFile { get; set; }
}
