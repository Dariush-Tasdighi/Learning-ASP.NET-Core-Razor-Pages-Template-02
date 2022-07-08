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
			builder.HasMany(current => current.Users)
				.WithOne(other => other.Role)
				.HasForeignKey(other => other.RoleId)
				.OnDelete(deleteBehavior: Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
				;
			// **************************************************

			// **************************************************
			builder
				.HasIndex(user => new { user.Name })
				.IsUnique(unique: true)
				;
			// **************************************************

			// **************************************************
			builder.HasData
			(
				new Domain.Models.Role
				{
					Ordering = 1,
					IsActive = true,
					IsSystemic = true,
					Name = Domain.SeedWork.Constant.SystemicRole.User,
					Id = Domain.SeedWork.Constant.SystemicRole.UserRoleId,
				},
				new Domain.Models.Role
				{
					Ordering = 2,
					IsActive = true,
					IsSystemic = true,
					Name = Domain.SeedWork.Constant.SystemicRole.Admin,
					Id = Domain.SeedWork.Constant.SystemicRole.AdminRoleId,
				},
				new Domain.Models.Role
				{
					Ordering = 3,
					IsActive = true,
					IsSystemic = true,
					Name = Domain.SeedWork.Constant.SystemicRole.Owner,
					Id = Domain.SeedWork.Constant.SystemicRole.OwnerRoleId,
				},
				new Domain.Models.Role
				{
					Ordering = 4,
					IsActive = true,
					IsSystemic = true,
					Name = Domain.SeedWork.Constant.SystemicRole.Programmer,
					Id = Domain.SeedWork.Constant.SystemicRole.ProgrammerRoleId,
				}
			);
			// **************************************************
		}
	}
}
