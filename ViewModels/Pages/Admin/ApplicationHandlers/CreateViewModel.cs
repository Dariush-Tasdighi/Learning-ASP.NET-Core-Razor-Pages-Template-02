namespace ViewModels.Pages.Admin.ApplicationHandlers
{
	public class CreateViewModel : object
	{
		public CreateViewModel() : base()
		{
		}

		public string? Name { get; set; }

		public string? Path { get; set; }

		public bool IsActive { get; set; }

		public string? Description { get; set; }

		public Domain.Enumerations.AccessType AccessType { get; set; }
	}
}
