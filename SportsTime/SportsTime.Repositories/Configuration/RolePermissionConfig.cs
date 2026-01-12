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

//public class RolePermissionConfig : IEntityTypeConfiguration<RolePermission>
//{
//	public void Configure(EntityTypeBuilder<RolePermission> builder)
//	{
//		builder.HasKey(x => new { x.RoleId, x.PermissionId });

//		builder.HasData(
//			Create(Role.Registered, Data.Enums.Permission.ReadMember),
//			Create(Role.Registered, Data.Enums.Permission.UpdateMember));
//	}

//	private static RolePermission Create(Role role, Data.Enums.Permission permission)
//	{
//		return new RolePermission
//		{
//			RoleId = role.Id,
//			PermissionId = (int)permission,
//		};
//	}
//}
