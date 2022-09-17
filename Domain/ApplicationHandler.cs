namespace Domain;

public class ApplicationHandler :
	Seedwork.Entity,
	Dtat.Seedwork.Abstractions.IEntityHasIsActive,
	Dtat.Seedwork.Abstractions.IEntityHasUpdateDateTime
{
	public ApplicationHandler(string name, string path) : base()
	{
		Name = name;
		Path = path;
		//SetUpdateDateTime();
		UpdateDateTime = InsertDateTime;
	}

	// **********
	public string Name { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsActive))]
	public bool IsActive { get; set; }
	// **********

	// **********
	public string Path { get; set; }
	// **********

	// **********
	public string? Title { get; set; }
	// **********

	// **********
	public string? Description { get; set; }
	// **********

	// **********
	public Enumerations.AccessType AccessType { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.UpdateDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTime UpdateDateTime { get; private set; }
	// **********

	public void SetUpdateDateTime()
	{
		UpdateDateTime =
			Dtat.Utility.Now;
	}
}
