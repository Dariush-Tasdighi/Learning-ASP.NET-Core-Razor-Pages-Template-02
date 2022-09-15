namespace Domain;

public class MenuItem :
	Seedwork.Entity,
	Dtat.Seedwork.Abstractions.IEntityHasIsActive,
	Dtat.Seedwork.Abstractions.IEntityHasIsUndeletable,
	Dtat.Seedwork.Abstractions.IEntityHasUpdateDateTime
{

	#region Constructor
	public MenuItem(string title) : base()
	{
		Title = title;

		SetUpdateDateTime();

		SubMenus =
			new System.Collections.Generic.List<MenuItem>();
	}
	#endregion /Constructor


	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.MenuItem),
		ResourceType = typeof(Resources.DataDictionary))]
	public System.Guid? ParentId { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.Title),
		ResourceType = typeof(Resources.DataDictionary))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.Title,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? Title { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.Link),
		ResourceType = typeof(Resources.DataDictionary))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.Link,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? Link { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IsActive),
		ResourceType = typeof(Resources.DataDictionary))]
	public bool IsActive { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IsPublic),
		ResourceType = typeof(Resources.DataDictionary))]
	public bool IsPublic { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IsUndeletable),
		ResourceType = typeof(Resources.DataDictionary))]
	public bool IsUndeletable { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IsDeleted),
		ResourceType = typeof(Resources.DataDictionary))]
	public bool IsDeleted { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.Icon),
		ResourceType = typeof(Resources.DataDictionary))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.Icon,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? Icon { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IconPosition),
		ResourceType = typeof(Resources.DataDictionary))]
	public Enumerations.IconPosition? IconPosition { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.UpdateDateTime),
		ResourceType = typeof(Resources.DataDictionary))]
	public System.DateTime UpdateDateTime { get; private set; }
	// **********

	public void SetUpdateDateTime()
	{
		UpdateDateTime = Seedwork.Utility.Now;
	}

	// **********
	public virtual MenuItem? Parent { get; set; }
	// **********

	// **********
	public virtual System.Collections.Generic.IList<MenuItem> SubMenus { get; set; }
	// **********

}
