using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsTime.Data.Entities;
using SportsTime.Data.Entities.Finance;
using SportsTime.Data.Entities.Sports;
using SportsTime.Data.Entities.Training;
using SportsTime.Data.Entities.Users;
using SportsTime.Repositories.Extensions.Interface;
using System.Reflection.Emit;

namespace SportsTime.Repositories;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	private readonly IUserAccessor _userAccessor;

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserAccessor userAccessor) : base(options)
	{
		Database.SetCommandTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds);
		_userAccessor = userAccessor;
	}

	#region  Training
	public DbSet<Trainee> Trainees { get; set; }
	public DbSet<Trainer> Trainers { get; set; }
	public DbSet<TraineeRate> TraineeRates { get; set; }
	public DbSet<Achievement> Achievements { get; set; }
	#endregion Training

	#region Sport
	public DbSet<Sport> Sports { get; set; }
	public DbSet<Championship> Championships { get; set; }
	public DbSet<Subscribtion> Subscribtions { get; set; }
	#endregion Sport

	#region Finance
	public DbSet<Expense> Expenses { get; set; }
	public DbSet<Revenue> Revenues { get; set; }
	public DbSet<Payroll> Payrolls { get; set; }
	#endregion Finance

	#region Users
	public DbSet<Client> Clients { get; set; }
	public DbSet<Employee> Employees { get; set; }
	//public DbSet<RolePermission> RolePermissions { get; set; }
	#endregion

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		// Customize the ASP.NET Identity model and override the defaults if needed.
		// For example, you can rename the ASP.NET Identity table names and more.
		// Add your customizations after calling base.OnModelCreating(builder);
		var cascadeFKs = builder.Model.GetEntityTypes()
					 .SelectMany(t => t.GetForeignKeys())
				   .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

		foreach (var fk in cascadeFKs)
		{
			fk.DeleteBehavior = DeleteBehavior.Restrict;
		}
		//to load entity configuration

	}

	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
	{
		foreach (var entry in ChangeTracker.Entries<BaseEntity>())
		{
			switch (entry.State)
			{
				case EntityState.Added:
					entry.Entity.CreatedBy = _userAccessor.GetCurrentUserId();
					entry.Entity.CreationDate = DateTime.Now;
					entry.Entity.IsDeleted = false;
					entry.Entity.CompanyId = _userAccessor.GetCurrentCompanyId();
					break;

				case EntityState.Modified:
					entry.Entity.ModifiedBy = _userAccessor.GetCurrentUserId();
					entry.Entity.ModifiedDate = DateTime.Now;
					break;
			}
		}
		return await base.SaveChangesAsync(cancellationToken);
	}

	public override int SaveChanges()
	{

		if (_userAccessor.GetCurrentUserId() == 0)
		{
			return base.SaveChanges();
		}
		foreach (var entry in ChangeTracker.Entries<BaseEntity>())
		{
			switch (entry.State)
			{
				case EntityState.Added:
					entry.Entity.CreatedBy = _userAccessor.GetCurrentUserId();
					entry.Entity.CreationDate = DateTime.Now;
					entry.Entity.IsDeleted = false;
					entry.Entity.CompanyId = _userAccessor.GetCurrentCompanyId();
					break;

				case EntityState.Modified:
					entry.Entity.ModifiedBy = _userAccessor.GetCurrentUserId();
					entry.Entity.ModifiedDate = DateTime.Now;
					break;
			}
		}
		return base.SaveChanges();
	}



}