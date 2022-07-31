using System.Linq;

namespace Infrastructure.Messages
{
	/// <summary>
	/// Version 3.0
	/// </summary>
	public static class Utility
	{
		static Utility()
		{
		}

		public static bool AddMessage
			(Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary tempData,
			MessageType type, string? message)
		{
			message =
				Dtat.Utility.FixText(text: message);

			if (message == null)
			{
				return false;
			}

			// **************************************************
			// به دلایل خیلی زیادی، کد ذیل به صورتی که ملاحظه می‌کنید
			// نوشته شده است، لذا در آن هیچ‌گونه تغییری اعمال نکنید
			// **************************************************
			System.Collections.Generic.List<string>? list;

			var tempDataItems =
				(tempData[key: type.ToString()] as
				System.Collections.Generic.IList<string>);

			if (tempDataItems == null)
			{
				list = new System.Collections.Generic.List<string>();
			}
			else
			{
				list =
					tempDataItems as
					System.Collections.Generic.List<string>;

				if (list == null)
				{
					list = tempDataItems.ToList();
				}
			}

			tempData[key: type.ToString()] = list;
			// **************************************************

			if (list.Contains(item: message))
			{
				return false;
			}

			list.Add(item: message);

			return true;
		}
	}
}
