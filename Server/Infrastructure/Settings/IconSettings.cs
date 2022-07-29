namespace Infrastructure.Settings
{
	public class IconSettings : object
	{
		public static readonly string KeyName = nameof(IconSettings);

		public IconSettings() : base()
		{
			UserIcons = new();

			TableIcons = new();

			SharedIcons = new();
		}

		public UserIcons UserIcons { get; set; }

		public TableIcons TableIcons { get; set; }

		public SharedIcons SharedIcons { get; set; }
	}

	public class SharedIcons : object
	{
		public SharedIcons() : base()
		{
		}

		// **********
		public string? None { get; set; }
		// **********

		// **********
		public string? User { get; set; }
		// **********

		// **********
		public string? DateTime { get; set; }
		// **********

		// **********
		public string? InsertDateTime { get; set; }
		// **********

		// **********
		public string? UpdateDateTime { get; set; }
		// **********

		// **********
		public string? VerifyDateTime { get; set; }
		// **********

		// **********
		public string? DeleteDateTime { get; set; }
		// **********

		// **********
		public string? Count { get; set; }
		// **********

		// **********
		public string? Introduction { get; set; }
		// **********

		// **********
		public string? Title { get; set; }
		// **********

		// **********
		public string? Name { get; set; }
		// **********

		// **********
		public string? Ordering { get; set; }
		// **********

		// **********
		public string? Description { get; set; }
		// **********

		// **********
		public string? Parent { get; set; }
		// **********

		// **********
		public string? Children { get; set; }
		// **********
	}


	public class TableIcons : object
	{
		public TableIcons() : base()
		{
		}

		// **********
		public string? True { get; set; }
		// **********

		// **********
		public string? False { get; set; }
		// **********

		// **********
		public string? None { get; set; }
		// **********

		// **********
		public string? Delete { get; set; }
		// **********

		// **********
		public string? Update { get; set; }
		// **********

		// **********
		public string? Details { get; set; }
		// **********

		// **********
		public string? Parent { get; set; }
		// **********

		// **********
		public string? Children { get; set; }
		// **********

		// **********
		public string? NextPage { get; set; }
		// **********

		// **********
		public string? PreviousPage { get; set; }
		// **********
	}

	public class UserIcons : object
	{
		public UserIcons() : base()
		{
		}

		// **********
		public string? Username { get; set; }
		// **********

		// **********
		public string? FullName { get; set; }
		// **********

		// **********
		public string? LastName { get; set; }
		// **********

		// **********
		public string? FirstName { get; set; }
		// **********

		// **********
		public string? Role { get; set; }
		// **********

		// **********
		public string? Gender { get; set; }
		// **********

		// **********
		public string? BirthDate { get; set; }
		// **********

		// **********
		public string? NationalCode { get; set; }
		// **********

		// **********
		public string? Password { get; set; }
		// **********

		// **********
		public string? EmailAddress { get; set; }
		// **********

		// **********
		public string? CellPhoneNumber { get; set; }
		// **********

		// **********
		public string? Description { get; set; }
		// **********
	}
}
