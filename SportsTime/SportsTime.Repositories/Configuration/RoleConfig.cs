//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using SportsTime.Data.Entities;
//using SportsTime.Data.Entities.Users;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SportsTime.Repositories.Configuration;

//public class RoleConfig : IEntityTypeConfiguration<Role>
//{
//	public void Configure(EntityTypeBuilder<Role> builder)
//	{
//		builder.HasKey(x => x.Id);
		
//		builder.HasMany(x => x.Permissions).WithMany().UsingEntity<RolePermission>();
		
//		builder.HasMany(x => x.ApplicationUsers).WithMany();

//		builder.HasData(Role.GetValues());
//	}
//}
