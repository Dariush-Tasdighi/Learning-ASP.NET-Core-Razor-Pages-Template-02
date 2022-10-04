namespace Domain;

public class Permission :
	Seedwork.Entity,
	Dtat.Seedwork.Abstractions.IEntityHasIsActive
{
	public Permission() : base()
	{
	}

	// **********
	// **********
	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Role))]
	public System.Guid RoleId { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Role))]
	public virtual Role? Role { get; set; }
	// **********
	// **********
	// **********

	// **********
	// **********
	// **********
	[System.ComponentModel.DataAnnotations.Display
	(ResourceType = typeof(Resources.DataDictionary),
	Name = nameof(Resources.DataDictionary.ApplicationHandler))]
	public System.Guid ApplicationHandlerId { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
	(ResourceType = typeof(Resources.DataDictionary),
	Name = nameof(Resources.DataDictionary.ApplicationHandler))]
	public virtual ApplicationHandler? ApplicationHandler { get; set; }
	// **********
	// **********
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsActive))]
	public bool IsActive { get; set; }
	// **********
}
