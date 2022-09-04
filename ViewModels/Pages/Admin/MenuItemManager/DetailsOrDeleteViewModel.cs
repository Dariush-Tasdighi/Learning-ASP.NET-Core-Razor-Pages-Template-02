namespace ViewModels.Pages.Admin.MenuItemManager
{
    public class DetailsOrDeleteViewModel : UpdateViewModel
    {
        public DetailsOrDeleteViewModel() : base()
        {
            InsertDateTime =
                Domain.SeedWork.Utility.Now;

            UpdateDateTime =
                Domain.SeedWork.Utility.Now;
        }

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.SubMenuItems),
            ResourceType = typeof(Resources.DataDictionary))]
        public int NumberOfSubMenus { get; init; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (Name = nameof(Resources.DataDictionary.IsDeleted),
            ResourceType = typeof(Resources.DataDictionary))]
        public bool IsDeleted { get; init; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.PageCount))]
        public int PageCount { get; set; }
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
