using System.Linq;

namespace Server.Pages.Admin.FileManager
{
	public class IndexModel : Infrastructure.BasePageModel
	{
		public IndexModel
			(Microsoft.Extensions.Hosting.IHostEnvironment hostEnvironment) : base()
		{
			PageRouting =
				"/Admin/FileManager/Index";

			HostEnvironment = hostEnvironment;

			PhysicalRootPath =
				$"{HostEnvironment.ContentRootPath}wwwroot"
				.Replace("/", "\\");
		}

		public string PageRouting { get; }

		public string PhysicalRootPath { get; }

		public string? CurrentPath { get; set; }

		public string? PhysicalCurrentPath { get; set; }

		private Microsoft.Extensions.Hosting.IHostEnvironment HostEnvironment { get; }

		public System.Collections.Generic.IList<System.IO.FileInfo>? Files { get; set; }

		public System.Collections.Generic.IList<System.IO.DirectoryInfo>? Directories { get; set; }

		public void OnGet(string? path)
		{
			CheckPathAndSetCurrentPath(path: path);

			SetDirectoriesAndFiles();
		}

		public void OnPostDeleteItems
			(string? path, System.Collections.Generic.IList<string>? items)
		{
			CheckPathAndSetCurrentPath(path: path);

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
								System.IO.File.Delete
									(path: physicalItemPath);
							}
						}
					}
					catch (System.Exception ex)
					{
					}
				}
			}

			SetDirectoriesAndFiles();
		}

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
				PhysicalCurrentPath = PhysicalRootPath;
			}
			// **************************************************
		}

		public void SetDirectoriesAndFiles()
		{
			if (string.IsNullOrWhiteSpace(PhysicalCurrentPath) ||
				System.IO.Directory.Exists(PhysicalCurrentPath) == false)
			{
				Files = null;
				Directories = null;

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
	}
}
