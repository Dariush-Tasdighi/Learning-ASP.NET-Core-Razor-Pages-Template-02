using System.Linq;

namespace Server.Pages.Admin.FileManager
{
	public class IndexModel : Infrastructure.BasePageModel
	{
		public IndexModel
			(Microsoft.Extensions.Hosting.IHostEnvironment hostEnvironment) : base()
		{
			HostEnvironment = hostEnvironment;

			RootPhysicalPath =
				$"{HostEnvironment.ContentRootPath}\\wwwroot";
		}

		public string RootPhysicalPath { get; }

		public string? CurrentPath { get; set; }

		public string? CurrentPhysicalPath { get; }

		private Microsoft.Extensions.Hosting.IHostEnvironment HostEnvironment { get; }

		public System.Collections.Generic.IList<System.IO.FileInfo>? Files { get; set; }

		public System.Collections.Generic.IList<System.IO.DirectoryInfo>? Directories { get; set; }

		public void OnGet(string? path)
		{
			// **************************************************
			if (string.IsNullOrWhiteSpace(path))
			{
				path = "\\";
			}
			else
			{
				path =
					path.Replace("/", "\\");

				if (path.StartsWith("\\") == false)
				{
					path =
						$"\\{path}";
				}

				if (path.EndsWith("\\") == false)
				{
					path =
						$"{path}\\";
				}


				while (path.Contains("\\\\"))
				{
					path =
						path.Replace("\\\\", "\\");
				}
			}

			CurrentPath = $"{path}";
			// **************************************************

			// **************************************************
			var physicalPath =
				$"{RootPhysicalPath}\\{path}";

			if (System.IO.Directory.Exists(path: physicalPath) == false)
			{
				physicalPath = RootPhysicalPath;
			}
			// **************************************************

			// **************************************************
			var directoryInfo =
				new System.IO.DirectoryInfo(path: physicalPath);

			Files =
				directoryInfo.GetFiles()
				.OrderBy(current => current.Name)
				.ToList()
				;

			Directories =
				directoryInfo.GetDirectories()
				.OrderBy(current => current.Name)
				.ToList()
				;
			// **************************************************
		}
	}
}
