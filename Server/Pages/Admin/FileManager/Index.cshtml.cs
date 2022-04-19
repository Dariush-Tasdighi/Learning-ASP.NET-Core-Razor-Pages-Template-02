using System.Linq;

namespace Server.Pages.Admin.FileManager
{
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
			CheckPathAndSetCurrentPath(path: path);

			SetDirectoriesAndFiles();
		}
		#endregion /OnGet

		#region OnPostDeleteItems
		public void OnPostDeleteItems
			(string? path, System.Collections.Generic.IList<string>? items)
		{
			CheckPathAndSetCurrentPath(path: path);

			if (ApplicationSettings.FileManagerSettings.DeleteItemsEnabled == false)
			{
				SetDirectoriesAndFiles();
				return;
			}

			if(items == null || items.Count == 0)
			{
				var errorMessage =
					Resources.FileManager.MessageYouDidNotSelectAnyItemsForDeleting;

				AddErrorToast(message: errorMessage);

				SetDirectoriesAndFiles();
				return;
			}

			if (items != null)
			{
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
							}
						}
					}
					catch //(System.Exception ex)
					{
					}
				}
			}

			SetDirectoriesAndFiles();
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
					var errorMessage = string.Format
						(Resources.FileManager.MessageFolderAlreadyExists, directoryName);

					AddErrorMessage(message: errorMessage);
					// **************************************************

					SetDirectoriesAndFiles();
					return;
				}

				System.IO.Directory
					.CreateDirectory(path: physicalPath);

				// **************************************************
				var successMessage = string.Format
					(Resources.FileManager.MessageFolderHasBeenCreated, directoryName);

				AddSuccessToast(message: successMessage);
				// **************************************************

				SetDirectoriesAndFiles();
			}
			catch (System.Exception ex)
			{
				AddErrorToast(message: ex.Message);
			}
		}
		#endregion /OnPostCreateDirectory

		#region OnPostUploadFiles
		public async System.Threading.Tasks.Task OnPostUploadFiles(
			string? path, System.Collections.Generic
			.List<Microsoft.AspNetCore.Http.IFormFile> files)
		{
			CheckPathAndSetCurrentPath(path: path);

			if (ApplicationSettings.FileManagerSettings.UploadFilesEnabled == false)
			{
				SetDirectoriesAndFiles();
				return;
			}

			if (files == null || files.Count == 0)
			{
				SetDirectoriesAndFiles();
				return;
			}

			foreach (var file in files)
			{
				if (file.Length > 0)
				{
					var fileName =
						file.FileName
						.Replace(" ", string.Empty);

					var physicalPathName =
						$"{PhysicalRootPath}{CurrentPath}{fileName}"
						.Replace("/", "\\");

					if (System.IO.Directory.Exists(path: physicalPathName) == false)
					{
						using var stream =
							System.IO.File.Create(path: physicalPathName);

						await file.CopyToAsync(target: stream);
					}
				}
			}

			SetDirectoriesAndFiles();
		}
		#endregion /OnPostUploadFiles

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
