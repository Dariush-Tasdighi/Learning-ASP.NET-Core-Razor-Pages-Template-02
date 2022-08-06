//namespace Infrastructure
//{
//	public static class HtmlContent
//	{
//		static HtmlContent()
//		{
//		}

//		public static string CreateButton
//		{
//			get
//			{
//				var result =
//					"<i class='bi bi-person-workspace'></i>"
//					+
//					" "
//					+
//					Resources.ButtonCaptions.Create
//					;

//				return result;
//			}
//		}

//		public static string UpdateLink
//		{
//			get
//			{
//				var result =
//					"<i class='bi bi bi-pencil-fill'></i>"
//					;

//				return result;
//			}
//		}

//		public static string DetailsLink
//		{
//			get
//			{
//				var result =
//					"<i class='bi bi-zoom-in'></i>"
//					;

//				return result;
//			}
//		}

//		public static string DeleteLink
//		{
//			get
//			{
//				var result =
//					"<i class='bi bi-trash-fill'></i>"
//					;

//				return result;
//			}
//		}

//		public static string GetCheckBox(bool value)
//		{
//			string result;

//			if (value)
//			{
//				result =
//					"<i class='bi bi-check-lg text-success'></i>"
//					;
//			}
//			else
//			{
//				result =
//					"<i class='bi bi bi-x text-danger'></i>"
//					;
//			}

//			return result;
//		}

//		public static string GetNumber(long? value)
//		{
//			if (value.HasValue == false)
//			{
//				return "-----";
//			}

//			string result =
//				value.Value.ToString("#,##0")
//				;

//			return result;
//		}

//		public static string GetDateTime(System.DateTime? value)
//		{
//			if (value.HasValue == false)
//			{
//				return "-----";
//			}

//			string result =
//				value.Value.ToString("yyyy/MM/dd - HH:mm:ss")
//				;

//			return result;
//		}
//	}
//}
