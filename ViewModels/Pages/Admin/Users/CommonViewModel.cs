﻿namespace ViewModels.Pages.Admin.Users;

public class CommonViewModel : object
{
	public CommonViewModel() : base()
	{
	}

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.EmailAddress),
		ResourceType = typeof(Resources.DataDictionary))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.EmailAddress,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: Constants.RegularExpression.EmailAddress,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.EmailAddress))]
	public string? EmailAddress { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.CellPhoneNumber),
		ResourceType = typeof(Resources.DataDictionary))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.FixedLength.CellPhoneNumber,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: Constants.RegularExpression.CellPhoneNumber,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.CellPhoneNumber))]
	public string? CellPhoneNumber { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.Role),
		ResourceType = typeof(Resources.DataDictionary))]

	//[System.ComponentModel.DataAnnotations.Required
	//	(ErrorMessageResourceType = typeof(Resources.Messages.Validations),
	//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public System.Guid? RoleId { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IsActive),
		ResourceType = typeof(Resources.DataDictionary))]
	public bool IsActive { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IsUndeletable),
		ResourceType = typeof(Resources.DataDictionary))]
	public bool IsUndeletable { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IsProgrammer),
		ResourceType = typeof(Resources.DataDictionary))]
	public bool IsProgrammer { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.Ordering),
		ResourceType = typeof(Resources.DataDictionary))]

	[System.ComponentModel.DataAnnotations.Range
		(minimum: Constants.MinValue.Ordering,
		maximum: Constants.MaxValue.Ordering,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Range))]
	public int Ordering { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.AdminDescription),
		ResourceType = typeof(Resources.DataDictionary))]

	[System.ComponentModel.DataAnnotations.DataType
		(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
	public string? AdminDescription { get; set; }
	// **********
}
