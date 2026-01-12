//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using SportsTime.Data.Entities.Users;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SportsTime.Repositories.Configuration;

//public class PermissionConfig : IEntityTypeConfiguration<Permission>
//{
//	public void Configure(EntityTypeBuilder<Permission> builder)
//	{
//		builder.HasKey(x => x.Id);
		
//		var permissions = Enum.GetValues<Data.Enums.Permission>()
//			.Select(p => new Permission { Id = (int)p, Name = p.ToString() });

//		builder.HasData(permissions);
//	}
//}
