using System.Linq;

namespace Server.Pages.Admin.FileManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constants.Role.Admin)]
	public class IndexModel : Infrastructure.BasePageModel
	{
		#region Constructor
		public IndexModel
			(Microsoft.Extensions.Hosting.IHostEnvironment hostEnvironment,
			Infrastructure.Settings.ApplicationSettings applicationSettings) : base()
		{
			HostEnvironment = hostEnvironment;
			ApplicationSettings = applicationSettings;

			PageAddress =
				"/Admin/FileManager/Index";

			PhysicalRootPath =
				$"{HostEnvironment.ContentRootPath}wwwroot";

			Files = new System.Collections.Generic.List<System.IO.FileInfo>();
			Directories = new System.Collections.Generic.List<System.IO.DirectoryInfo>();
		}
		#endregion /Constructor

		#region Public Read Only Property(ies)
		public string PageAddress { get; }

		public string PhysicalRootPath { get; }

		public Microsoft.Extensions.Hosting.IHostEnvironment HostEnvironment { get; }

		public Infrastructure.Settings.ApplicationSettings ApplicationSettings { get; }
		#endregion /Public Read Only Property(ies)

		#region Public Property(ies)
		public string? CurrentPath { get; set; }

		public string? PhysicalCurrentPath { get; set; }

		public System.Collections.Generic.IList<System.IO.FileInfo> Files { get; set; }

		public System.Collections.Generic.IList<System.IO.DirectoryInfo> Directories { get; set; }
		#endregion /Public Property(ies)

		#region OnGet
		public void OnGet(string? path)
		{
			try
			{
				CheckPathAndSetCurrentPath(path: path);

				SetDirectoriesAndFiles();
			}
			catch (System.Exception ex)
			{
				AddToastError
					(message: ex.Message);
			}
		}
		#endregion /OnGet

		#region OnPostDeleteItems
		public void OnPostDeleteItems
			(string? path, System.Collections.Generic.IList<string>? items)
		{
			try
			{
				CheckPathAndSetCurrentPath(path: path);

				if (ApplicationSettings.FileManagerSettings.DeleteItemsEnabled == false)
				{
					SetDirectoriesAndFiles();
					return;
				}

				if (items == null || items.Count == 0)
				{
					var errorMessage =
						"You did not select any files or folders for deleting!";

					AddToastError
						(message: errorMessage);

					SetDirectoriesAndFiles();
					return;
				}

				foreach (var item in items)
				{
					try
					{
						var physicalItemPath =
							$"{PhysicalRootPath}{CurrentPath}{item}"
							.Replace("/", "\\");

						if (System.IO.Directory.Exists(path: physicalItemPath))
						{
							System.IO.Directory.Delete
								(path: physicalItemPath, recursive: true);

							var successMessage =
								$"The direcotry ({item}) deleted successfully.";

							AddToastSuccess
								(message: successMessage);
						}
						else
						{
							if (System.IO.File.Exists(path: physicalItemPath))
							{
								// نوشتن دو دستور ذیل بسیار اهمیت دارد
								System.GC.Collect();
								System.GC.WaitForPendingFinalizers();

								System.IO.File.Delete
									(path: physicalItemPath);

								var successMessage =
									$"The file ({item}) deleted successfully.";

								AddToastSuccess
									(message: successMessage);
							}
						}
					}
					catch (System.Exception ex)
					{
						AddToastError
							(message: ex.Message);
					}
				}

				SetDirectoriesAndFiles();
			}
			catch (System.Exception ex)
			{
				AddToastError
					(message: ex.Message);
			}
		}
		#endregion /OnPostDeleteItems

		#region OnPostCreateDirectory
		public void OnPostCreateDirectory
			(string? path, string? directoryName)
		{
			try
			{
				CheckPathAndSetCurrentPath(path: path);

				if (ApplicationSettings.FileManagerSettings.CreateDirectoryEnabled == false)
				{
					SetDirectoriesAndFiles();
					return;
				}

				if (string.IsNullOrWhiteSpace(directoryName))
				{
					SetDirectoriesAndFiles();
					return;
				}

				directoryName =
					directoryName
					.Replace(" ", string.Empty);

				var physicalPath =
					$"{PhysicalRootPath}{CurrentPath}{directoryName}"
					.Replace("/", "\\");

				if (System.IO.Directory.Exists(path: physicalPath))
				{
					// **************************************************
					var errorMessage =
						$"The [{directoryName}] folder already exists!";

					AddPageError
						(message: errorMessage);
					// **************************************************

					SetDirectoriesAndFiles();
					return;
				}

				System.IO.Directory
					.CreateDirectory(path: physicalPath);

				// **************************************************
				var successMessage =
					$"The [{directoryName}] folder has been created successfully.";

				AddToastSuccess
					(message: successMessage);
				// **************************************************

				SetDirectoriesAndFiles();
			}
			catch (System.Exception ex)
			{
				AddToastError
					(message: ex.Message);
			}
		}
		#endregion /OnPostCreateDirectory

		#region OnPostUploadFilesAsync
		public async System.Threading.Tasks.Task
			OnPostUploadFilesAsync
			(string? path, System.Collections.Generic
			.List<Microsoft.AspNetCore.Http.IFormFile> files)
		{
			try
			{
				CheckPathAndSetCurrentPath(path: path);

				if (ApplicationSettings.FileManagerSettings.UploadFilesEnabled == false)
				{
					SetDirectoriesAndFiles();
					return;
				}

				if (files == null || files.Count == 0)
				{
					var errorMessage =
						"You did not specify any files for uploading!";

					AddToastError
						(message: errorMessage);

					return;
				}

				foreach (var file in files)
				{
					await CheckFileValidationAndSaveAsync
						(overwriteIfFileExists: true, file: file);
				}

				SetDirectoriesAndFiles();
			}
			catch (System.Exception ex)
			{
				AddToastError
					(message: ex.Message);
			}
		}
		#endregion /OnPostUploadFilesAsync

		#region CheckFileValidationAndSaveAsync
		private async System.Threading.Tasks.Task<bool>
			CheckFileValidationAndSaveAsync
			(bool overwriteIfFileExists, Microsoft.AspNetCore.Http.IFormFile? file)
		{
			var result =
				CheckFileValidation(file: file);

			if (result == false)
			{
				return false;
			}

			var fileName =
				file!.FileName
				.Trim()
				.Replace(" ", "_");

			var physicalPathName =
				$"{PhysicalRootPath}{CurrentPath}{fileName}"
				.Replace("/", "\\");

			if (overwriteIfFileExists == false)
			{
				if (System.IO.File.Exists(path: physicalPathName))
				{
					var errorMessage = string.Format
						("File '{0}' already exists!", fileName);

					AddToastError
						(message: errorMessage);

					return false;
				}
			}

			using (var stream = System.IO.File.Create(path: physicalPathName))
			{
				await file.CopyToAsync(target: stream);

				await stream.FlushAsync();

				stream.Close();
			}

			if (string.Compare(file.FileName, fileName, ignoreCase: true) == 0)
			{
				var successMessage = string.Format
					("File '{0}' uploaded successfully.", fileName);

				AddToastSuccess
					(message: successMessage);
			}
			else
			{
				var successMessage = string.Format
					("File '{0}' with the name of '{1}' uploaded successfully.",
					file.FileName, fileName);

				AddToastSuccess
					(message: successMessage);
			}

			return true;
		}
		#endregion /CheckFileValidationAndSaveAsync

		#region CheckFileValidation
		private bool CheckFileValidation
			(Microsoft.AspNetCore.Http.IFormFile? file)
		{
			if (file == null)
			{
				var errorMessage =
					"You did not specify any files for uploading!";

				AddToastError
					(message: errorMessage);

				return false;
			}

			if (file.Length == 0)
			{
				var errorMessage =
					$"The file ({file.FileName}) did not uploaded successfully!";

				AddToastError
					(message: errorMessage);

				return false;
			}

			var fileExtension =
				System.IO.Path.GetExtension
				(path: file.FileName)?.ToLower();

			if (fileExtension == null)
			{
				var errorMessage =
					$"The file ({file.FileName}) does not have any extension!";

				AddToastError
					(message: errorMessage);

				return false;
			}

			var permittedFileExtensions =
				ApplicationSettings.FileManagerSettings.PermittedFileExtensions.ToList();

			if (permittedFileExtensions.Contains(item: fileExtension) == false)
			{
				var errorMessage =
					$"The file ({file.FileName}) does not have a valid extension!";

				AddToastError
					(message: errorMessage);

				return false;
			}

			return true;
		}
		#endregion /CheckFileValidation

		#region CheckPathAndSetCurrentPath
		/// <summary>
		/// قانون
		///
		/// CurrentPath:
		///		/
		///		/Images/
		///
		/// یعنی همیشه دو طرف آن / دارد
		/// </summary>
		public void CheckPathAndSetCurrentPath(string? path)
		{
			// **************************************************
			string fixedPath = "/";

			if (string.IsNullOrWhiteSpace(path) == false)
			{
				fixedPath =
					path.Replace("\\", "/");

				if (fixedPath.StartsWith("/") == false)
				{
					fixedPath =
						$"/{fixedPath}";
				}

				if (fixedPath.EndsWith("/") == false)
				{
					fixedPath =
						$"{fixedPath}/";
				}

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

			// **************************************************
			PhysicalCurrentPath =
				$"{PhysicalRootPath}{CurrentPath}"
				.Replace("/", "\\");

			if (System.IO.Directory.Exists(path: PhysicalCurrentPath) == false)
			{
				CurrentPath = "/";
				PhysicalCurrentPath = PhysicalRootPath;
			}
			// **************************************************
		}
		#endregion /CheckPathAndSetCurrentPath

		#region SetDirectoriesAndFiles
		public void SetDirectoriesAndFiles()
		{
			if (string.IsNullOrWhiteSpace(PhysicalCurrentPath) ||
				System.IO.Directory.Exists(PhysicalCurrentPath) == false)
			{
				Files = new System.Collections.Generic.List<System.IO.FileInfo>();
				Directories = new System.Collections.Generic.List<System.IO.DirectoryInfo>();

				return;
			}

			var directoryInfo =
				new System.IO.DirectoryInfo(path: PhysicalCurrentPath);

			Files =
				directoryInfo.GetFiles()
				.OrderBy(current => current.Extension)
				.ThenBy(current => current.Name)
				.ToList()
				;

			Directories =
				directoryInfo.GetDirectories()
				.OrderBy(current => current.Name)
				.ToList()
				;
		}
		#endregion /SetDirectoriesAndFiles
	}
}
