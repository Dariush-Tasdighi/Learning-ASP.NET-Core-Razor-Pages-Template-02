using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Server.Pages.Account;

[Microsoft.AspNetCore.Authorization.Authorize]
public class UpdateProfileModel : Infrastructure.BasePageModelWithDatabaseContext
{
    #region Constructor(s)
    public UpdateProfileModel(Data.DatabaseContext databaseContext,
        Microsoft.AspNetCore.Hosting.IWebHostEnvironment webHostEnvironment,
        Infrastructure.Settings.ApplicationSettings applicationSettings,
        Microsoft.Extensions.Logging.ILogger<UpdateProfileModel> logger) : base(databaseContext: databaseContext)
    {
        ViewModel = new();

        Logger = logger;

        WebHostEnvironment = webHostEnvironment;

        ApplicationSettings = applicationSettings;


    }
    #endregion /Constructor(s)

    #region Property(ies)
    // **********
    private Microsoft.Extensions.Logging.ILogger<UpdateProfileModel> Logger { get; }
    // **********
    public string? CurrentPath { get; set; }
    // **********
    public string PhysicalRootPath { get; set; }
    // **********
    public string? PhysicalCurrentPath { get; set; }
    // **********
    public Microsoft.AspNetCore.Hosting.IWebHostEnvironment WebHostEnvironment { get; }
    // **********
    public Infrastructure.Settings.ApplicationSettings ApplicationSettings { get; set; }
    // **********

    #endregion /Property(ies)

    #region BindProperty(ies)
    // **********
    [Microsoft.AspNetCore.Mvc.BindProperty]
    public ViewModels.Pages.Account.ProfileViewModel ViewModel { get; set; }
    // **********
    #endregion /BindProperty(ies)
    // **********
    #region OnGet
    public async System.Threading.Tasks.Task
        <Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
    {
        try
        {
            if (id.HasValue == false)
            {
                AddToastError
                    (message: Resources.Messages.Errors.IdIsNull);

                return RedirectToPage(pageName: "profile");
            }


            ViewModel = DatabaseContext.Users
                .Where(Current => Current.Id == id)
                .Select(Current => new ViewModels.Pages.Account.ProfileViewModel()
                {
                    Id = Current.Id,
                    PhotoPath = Current.UserPhoto,
                    CellPhoneNumber = Current.CellPhoneNumber,
                    EmailAddress = Current.EmailAddress,
                    FullName = Current.FullName,
                    Username = Current.Username,
                    Description = Current.Description,
                    Role = Current.Role.Name,
                    IsActive = Current.IsActive,
                    IsProfilePublic = Current.IsProfilePublic,

                }).FirstOrDefault();

            if (ViewModel == null)
            {
                AddToastError
                    (message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

                return RedirectToPage(pageName: "Profile");
            }
            var fileName = id.ToString();
            if (ViewModel.PhotoPath != null)
            {
                var fileType = ViewModel.PhotoPath.Split('.')[1];

                var physicalPathName = System.IO.Path.Combine
                (WebHostEnvironment.WebRootPath, ApplicationSettings.FileManagerSettings.UserPhotoPath, fileName) + "." + fileType;

                if (!System.IO.File.Exists(path: physicalPathName))
                {
                    ViewModel.PhotoPath = "";
                }
            }
        }
            catch (System.Exception ex)
        {
            Logger.LogError(message: ex.Message);
            AddPageError(message: Resources.Messages.Errors.UnexpectedError);
        }
        finally
        {
            await DisposeDatabaseContextAsync();
        }
        return Page();
    }
    #endregion /OnGet
    // **********
    #region CheckPathAndSetCurrentPath

    public string CheckPathAndSetCurrentPath(string? path)
    {
        // **************************************************
        string fixedPath = "/";

        if (string.IsNullOrWhiteSpace(path) == false)
        {
            fixedPath =
                path.Replace("\\", "/");

            while (fixedPath.Contains("//"))
            {
                fixedPath =
                    fixedPath.Replace("//", "/");
            }
        }
        // **************************************************

        // **************************************************
        CurrentPath = fixedPath;
        // **************************************************

        return PhysicalCurrentPath = CurrentPath;
        // **************************************************
    }
    #endregion /CheckPathAndSetCurrentPath
    // **********
    #region OnPost

    public async System.Threading.Tasks.Task<IActionResult>
        OnPostAsync(System.Guid? id, Microsoft.AspNetCore.Http.IFormFile? file)
    {
        if (id.HasValue == false)
        {
            AddToastError
                (message: Resources.Messages.Errors.IdIsNull);

            return RedirectToPage(pageName: "Index");
        }

        try
        {
            var foundedItem = await DatabaseContext.Users
           .Where(Current => Current.Id == id)
           .FirstOrDefaultAsync();

            if (foundedItem == null)
            {
                string errorMessage = string.Format
                    (Resources.Messages.Errors.NotFound,
                    Resources.DataDictionary.User);

                AddToastError(message: errorMessage);

                return Page();
            }
            else
            {

                var fixedUserName =
                    Dtat.Utility.FixText
                    (text: ViewModel.Username); ;

                var foundedAny =
                    await
                    DatabaseContext.Roles
                    .Where(current => current.Id != ViewModel.Id)
                    .Where(current => current.Name.ToLower() == fixedUserName.ToLower())
                    .AnyAsync();

                if (foundedAny)
                {
                    // **************************************************
                    var errorMessage = string.Format
                        (Resources.Messages.Errors.AlreadyExists,
                        Resources.DataDictionary.Username);

                    AddPageError(message: errorMessage);
                    // **************************************************

                    return Page();
                }

                if (file == null)
                {
                    foundedItem.UserPhoto = null;
                }

                else 
                {
                    await CheckFileValidationAndSaveAsync
                           (file: file, id: id);

                    foundedItem.UserPhoto = $"{id}.{file.ContentType.Split('/')[1]}";

                }
                foundedItem.Username = fixedUserName;
                
                foundedItem.Description = Dtat.Utility.FixText(text: ViewModel.Description);
                foundedItem.IsProfilePublic = ViewModel.IsProfilePublic;
                foundedItem.CellPhoneNumber = ViewModel.CellPhoneNumber;
                foundedItem.EmailAddress = ViewModel.EmailAddress;
                foundedItem.FullName = Dtat.Utility.FixText
                    (text: ViewModel.FullName);
                foundedItem.SetUpdateDateTime();
                // **************************************************
                var isValid =
                    Domain.SeedWork.ValidationHelper.IsValid(entity: foundedItem);

                var results =
                    Domain.SeedWork.ValidationHelper.GetValidationResults(entity: foundedItem);
                // **************************************************

                if (isValid)
                {
                    int affectedRows =
                        await DatabaseContext.SaveChangesAsync();

                    string successMessage = string.Format
                        (Resources.Messages.Successes.Updated,
                        Resources.DataDictionary.User);

                    AddToastSuccess(message: successMessage);
                }
                return Redirect("profile");
            }

        }


        catch (System.Exception ex)
        {
            AddToastError
                (message: ex.Message);
        }

        return Redirect("profile");
    }

    #endregion /OnPost
    // **********
    // **********
    #region CheckFileValidationAndSaveAsync
    private async System.Threading.Tasks.Task<bool> CheckFileValidationAndSaveAsync
        (Microsoft.AspNetCore.Http.IFormFile? file, System.Guid? id)
    {
        var result =
            CheckFileValidation(file: file);

        if (result == false)
        {
            return false;
        }

        var fileName = id.ToString();

        var fileType = file.ContentType.Split('/')[1];

        var physicalPathName = System.IO.Path.Combine
            (WebHostEnvironment.WebRootPath, ApplicationSettings.FileManagerSettings.UserPhotoPath, fileName) + "." + fileType;

        using (var stream = System.IO.File.Create(path: physicalPathName))
        {
            await file.CopyToAsync(target: stream);

            await stream.FlushAsync();

            stream.Close();
        }

        return true;
    }
    #endregion CheckFileValidationAndSaveAsync
    // **********
    // **********
    #region CheckFileValidation
    private bool CheckFileValidation
        (Microsoft.AspNetCore.Http.IFormFile? file)
    {
        if (file == null)
        {
            var errorMessage =
                "You did not specify any file for uploading!";

            AddToastError
                (message: errorMessage);

            return false;
        }

        if (file.Length == 0)
        {
            var errorMessage = string.Format
                ("File '{0}' did not uploaded successfully!", file.FileName);

            AddToastError
                (message: errorMessage);

            return false;
        }

        var fileExtension =
            System.IO.Path.GetExtension
            (path: file.FileName)?.ToLower();

        if (fileExtension == null)
        {
            var errorMessage = string.Format
                ("File '{0}' does not have any extension!", file.FileName);

            AddToastError
                (message: errorMessage);

            return false;
        }

        //var permittedFileExtensions = new string[]
        //    { ".mp3", ".mp4", ".pdf", ".zip", ".rar", ".doc", ".docx", ".ico", ".png", ".jpg", ".jpeg", ".bmp", ".txt" };

        //if (permittedFileExtensions.ToList().Contains(item: fileExtension) == false)
        //{
        //    var errorMessage = string.Format
        //        ("Site does not support file '{0}' extension!", file.FileName);

        //    AddErrorToast
        //        (message: errorMessage);

        //    return false;
        //}

        return true;
    }
    #endregion CheckFileValidation
    // **********
}
