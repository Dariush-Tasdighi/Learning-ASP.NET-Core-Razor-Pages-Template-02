namespace Domain;

public class Permission :
	Seedwork.Entity,
	Dtat.Seedwork.Abstractions.IEntityHasIsActive
{
	// **********
	// **********
	// **********
	public System.Guid ApplicationHandlerId { get; set; }

	public virtual ApplicationHandler? ApplicationHandler { get; set; }
	// **********
	// **********
	// **********

	// **********
	// **********
	// **********
	//public System.Guid RoleId { get; set; }

	//public virtual Role? Role { get; set; }
	// **********
	// **********
	// **********

	//TODO: Replace it with Navigation Property
	// **********
	public string? Role { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsActive))]
	public bool IsActive { get; set; }
	// **********
}
