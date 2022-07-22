namespace Data.Configurations
{
	internal class RoleConfiguration : object,
		Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Role>
	{
		public RoleConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Role> builder)
		{
			// **************************************************
			//builder
			//	.HasIndex(propertyNames: "Name")
			//	.IsUnique(unique: true)
			//	;

			//builder
			//	.HasIndex(propertyNames: nameof(Domain.Role.Name))
			//	.IsUnique(unique: true)
			//	;

			//builder
			//	.HasIndex(indexExpression: current => current.Name)
			//	.IsUnique(unique: true)
			//	;

			//builder
			//	.HasIndex(indexExpression: current => new { current.Name })
			//	.IsUnique(unique: true)
			//	;

			builder
				.HasIndex(current => new { current.Name })
				.IsUnique(unique: true)
				;
			// **************************************************

			// **************************************************
			builder
				.HasMany(current => current.Users)
				.WithOne(other => other.Role)
				.IsRequired(required: true)
				.HasForeignKey(other => other.RoleId)
				.OnDelete(deleteBehavior:
					Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
				;
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			var role =
				new Domain.Role(name: "کاربر معمولی")
				{
					//Id,
					//Name,
					//Users
					//InsertDateTime,
					//UpdateDateTime,

					Ordering = 0,

					IsActive = true,
					IsSystemic = true,
					IsUndeletable = true,

					Description = null,
				};

			role.SetId(id: Domain.Role.UserRoleId);

			builder.HasData(data: role);
			// **************************************************
			// **************************************************
			// **************************************************
		}
	}
}
