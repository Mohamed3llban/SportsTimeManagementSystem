using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsTime.Data.Entities;

public class BaseEntity
{
	public int Id { get; set; }
	public int CreatedBy { get; set; }
	public int CompanyId { get; set; }
	public int? ModifiedBy { get; set; }
	public DateTime CreationDate { get; set; }
	public DateTime? ModifiedDate { get; set; }
	public bool IsDeleted { get; set; }

	//[ForeignKey(nameof(CreatedBy))]
	//public virtual UserDefinition UserDefinition { set; get; }
}
