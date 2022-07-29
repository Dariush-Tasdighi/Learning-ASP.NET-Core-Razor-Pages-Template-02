using Domain;

namespace ViewModels.Pages.Admin.RoleManager
{
	public class UpdateRoleViewModel : Base.RoleExtendedViewModel
	{
		public UpdateRoleViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Ordering),
			ResourceType = typeof(Resources.DataDictionary))]

		[System.ComponentModel.DataAnnotations.Range
			(minimum: Domain.SeedWork.Constant.Minimum.Ordering,
			maximum: Domain.SeedWork.Constant.Maximum.Ordering,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Range))]
		public int Ordering { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Description),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Description { get; set; }
		// **********
	}
}
