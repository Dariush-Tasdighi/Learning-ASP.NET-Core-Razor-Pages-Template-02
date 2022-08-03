namespace ViewModels.Pages.Admin.Roles
{
	public class IndexItemViewModel : object
	{
		public IndexItemViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Id))]
		public System.Guid Id { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsActive))]
		public bool IsActive { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Name))]
		public string? Name { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Ordering))]
		public int Ordering { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.UserCount))]
		public int UserCount { get; set; }
		// **********

		// **********
		// **********
		// **********
		public System.DateTime InsertDateTime { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.InsertDateTime))]
		public string DisplayInsertDateTime
		{
			get
			{
				var result =
					InsertDateTime.ToString
					(format: Domain.SeedWork.Constants.Format.DateTime);

				return result;
			}
		}
		// **********
		// **********
		// **********

		// **********
		// **********
		// **********
		public System.DateTime UpdateDateTime { get; set; }
		// **********
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.UpdateDateTime))]
		public string DisplayUpdateDateTime
		{
			get
			{
				var result =
					UpdateDateTime.ToString
					(format: Domain.SeedWork.Constants.Format.DateTime);

				return result;
			}
		}
		// **********
		// **********
		// **********
	}
}
