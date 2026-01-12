using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Models.DTOs.Training;

public class TraineeModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public string Name { get; set; } = "";
    [Required(ErrorMessage = "RequiredField")]
    public int Code { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public int Status { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public int Gender { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public int SportId { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public int TrainerId { get; set; }
    public string? Email { get; set; } = "";
    [Required(ErrorMessage = "RequiredField")]
    public string Address { get; set; } = "";
    [Required(ErrorMessage = "RequiredField")]
    public string PhoneNumber { get; set; } = "";
    [Required(ErrorMessage = "RequiredField")]
    public DateTime JoinDate { get; set; }
    [Required(ErrorMessage = "RequiredField")]
    public DateTime DateOfBirth { get; set; }
    public string? Notes { get; set; } = "";
    public string? ImagePath { get; set; } = "";
    public IFormFile? ImageFile { get; set; }
    public string SportName { get; set; } = "";
    public string TrainerName { get; set; } = "";
    public int? CreatedBy { get; set; } = 0;
    public int? CompanyId { get; set; } = 0;
    public int? ModifiedBy { get; set; } = 0;
    public DateTime? CreationDate { get; set; } = new DateTime();
    public DateTime? ModifiedDate { get; set; } = new DateTime();
}