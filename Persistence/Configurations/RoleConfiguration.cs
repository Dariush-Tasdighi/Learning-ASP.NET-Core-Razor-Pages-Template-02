using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
	public class RoleConfiguration :
		object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Models.Role>
	{
		public RoleConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata
			.Builders.EntityTypeBuilder<Domain.Models.Role> builder)
		{
			// **************************************************
			builder
				.Property(current => current.Name)
				.HasMaxLength(maxLength: Domain.Models.Role.NameMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Description)
				.HasMaxLength(maxLength: Domain.Models.Role.DescriptionMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.HasMany(current => current.Users)
				.WithOne(other => other.Role)
				.HasForeignKey(other => other.RoleId)
				.OnDelete(deleteBehavior: Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
				;
			// **************************************************

			// **************************************************
			builder
				.HasIndex(current => new { current.Name })
				.IsUnique(unique: true)
				;
			// **************************************************

			// **************************************************
			builder
				.HasIndex(current => new { current.Ordering })
				.IsClustered(clustered: false)
				.IsUnique(unique: false)
				;
			// **************************************************

			// **************************************************
			builder.HasData
			(
				new Domain.Models.Role
				{
					Ordering = 10000,
					IsActive = true,
					IsSystemic = true,
					IsDeletable = false,
					Name = Domain.SeedWork.Constant.SystemicRole.User,
					Id = Domain.SeedWork.Constant.SystemicRole.UserRoleId,
				},
				new Domain.Models.Role
				{
					Ordering = 10001,
					IsActive = true,
					IsSystemic = true,
					IsDeletable = false,
					Name = Domain.SeedWork.Constant.SystemicRole.Admin,
					Id = Domain.SeedWork.Constant.SystemicRole.AdminRoleId,
				},
				new Domain.Models.Role
				{
					Ordering = 10002,
					IsActive = false,
					IsSystemic = true,
					IsDeletable = false,
					Name = Domain.SeedWork.Constant.SystemicRole.Owner,
					Id = Domain.SeedWork.Constant.SystemicRole.OwnerRoleId,
				},
				new Domain.Models.Role
				{
					Ordering = 10003,
					IsActive = false,
					IsSystemic = true,
					Name = Domain.SeedWork.Constant.SystemicRole.Programmer,
					Id = Domain.SeedWork.Constant.SystemicRole.ProgrammerRoleId,
				}
			);
			// **************************************************
		}
	}
}
