namespace Data.Configurations
{
	internal class UserLoginConfiguration : object,
		Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.LoginLog>
	{
		public UserLoginConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.LoginLog> builder)
		{
			// **************************************************
			// **************************************************
			// **************************************************
			builder
				.Property(current => current.UserIP)
				.IsUnicode(unicode: false)
				;

			builder
				.HasIndex(current => new { current.UserIP })
				.IsUnique(unique: false)
				;
			// **************************************************
			// **************************************************
			// **************************************************
		}
	}
}
