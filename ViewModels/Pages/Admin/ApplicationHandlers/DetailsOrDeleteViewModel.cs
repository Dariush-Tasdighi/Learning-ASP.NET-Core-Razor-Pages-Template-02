namespace ViewModels.Pages.Admin.ApplicationHandlers;

public class DetailsOrDeleteViewModel : UpdateViewModel
{
	public DetailsOrDeleteViewModel() : base()
	{
		Permissions =
			new Shared.KeyValueViewModel();
	}

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.InsertDateTime))]
	public System.DateTime InsertDateTime { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.UpdateDateTime))]
	public System.DateTime UpdateDateTime { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.AccessType))]
	public string AccessTypeTitle
	{
		get
		{
			string title = string.Empty;

			switch (AccessType)
			{
				case Domain.Enumerations.AccessType.Special:
				{
					title =
						Resources.DataDictionary.Special;

					break;
				}
				case Domain.Enumerations.AccessType.Registered:
				{
					title =
						Resources.DataDictionary.Registered;

					break;
				}
				case Domain.Enumerations.AccessType.Public:
				{
					title =
						Resources.DataDictionary.Public;

					break;
				}
			}

			return title;
		}
	}
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Permissions))]
	public Shared.KeyValueViewModel Permissions { get; set; }
	// **********
}
