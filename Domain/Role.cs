namespace Domain
{
	// دستور ذیل کار نمی‌کند
	//[Microsoft.EntityFrameworkCore.Index
	//	(propertyNames: nameof(Name), IsUnique = true)]
	public class Role :
		SeedWork.Entity,
		SeedWork.IEntityCanSetId,
		SeedWork.IEntityHasIsActive,
		SeedWork.IEntityHasIsSystemic,
		SeedWork.IEntityHasIsUndeletable,
		SeedWork.IEntityHasUpdateDateTime
	{
		#region Static(s)
		public static readonly System.Guid UserRoleId = new(g: "2A533503-E7E1-4E08-98DD-33973A69AE15");
		#endregion /Static(s)

		#region Constructor
		public Role(string name) : base()
		{
			Name = name;

			SetUpdateDateTime();

			Users =
				new System.Collections.Generic.List<User>();
		}
		#endregion /Constructor

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsActive))]
		public bool IsActive { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsSystemic))]
		public bool IsSystemic { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsUndeletable))]
		public bool IsUndeletable { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.UpdateDateTime))]

		[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
			(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
		public System.DateTime UpdateDateTime { get; private set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Name))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

		[System.ComponentModel.DataAnnotations.MaxLength
			(length: SeedWork.Constant.MaxLength.Name,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
		public string Name { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Description))]
		public string? Description { get; set; }
		// **********

		public void SetUpdateDateTime()
		{
			UpdateDateTime =
				Dtat.Utility.Now;
		}

		public void SetId(System.Guid id)
		{
			Id = id;
		}

		// **********
		public virtual System.Collections.Generic.IList<User> Users { get; private set; }
		// **********
	}
}
