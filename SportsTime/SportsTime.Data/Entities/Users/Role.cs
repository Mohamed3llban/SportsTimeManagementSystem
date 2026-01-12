//using SportsTime.Data.Entities.Primitives;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace SportsTime.Data.Entities.Users;
//[Table("Roles", Schema = "User")]
//public sealed class Role : Enumeration<Role>
//{
//    public static readonly Role Registered = new(1, "Registered");
//    public Role(int id, string name) : base(id, name)
//    {
//    }

//    public ICollection<Permission> Permissions { get; set; }
//    public ICollection<ApplicationUser> ApplicationUsers { get; set; }
//}
