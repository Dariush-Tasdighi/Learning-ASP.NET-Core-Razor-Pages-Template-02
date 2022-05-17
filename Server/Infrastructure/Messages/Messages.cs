namespace Infrastructure.Messages
{
	/// <summary>
	/// Version 2.0
	/// </summary>
	public class Messages : object
	{
		public enum MessageType
		{
			PageError,
			PageWarning,
			PageSuccess,

			ToastError,
			ToastWarning,
			ToastSuccess,
		}

		public static readonly string KeyName = "Messages";

		public static string? FixText(string? text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}

			text =
				text.Trim();

			while (text.Contains("  "))
			{
				text =
					text.Replace("  ", " ");
			}

			return text;
		}

		public Messages() : base()
		{
			_pageErrors =
				new System.Collections.Generic.List<string>();

			_pageWarnings =
				new System.Collections.Generic.List<string>();

			_pageSuccesses =
				new System.Collections.Generic.List<string>();

			_toastErrors =
				new System.Collections.Generic.List<string>();

			_toastWarnings =
				new System.Collections.Generic.List<string>();

			_toastSuccesses =
				new System.Collections.Generic.List<string>();
		}

		//[Newtonsoft.Json.JsonProperty]
		private readonly System.Collections.Generic.List<string> _pageErrors;

		//[Newtonsoft.Json.JsonIgnore]
		public System.Collections.Generic.IReadOnlyList<string> PageErrors
		{
			get
			{
				return _pageErrors;
			}
		}

		private readonly System.Collections.Generic.List<string> _pageWarnings;

		public System.Collections.Generic.IReadOnlyList<string> PageWarnings
		{
			get
			{
				return _pageWarnings;
			}
		}

		private readonly System.Collections.Generic.List<string> _pageSuccesses;

		public System.Collections.Generic.IReadOnlyList<string> PageSuccesses
		{
			get
			{
				return _pageSuccesses;
			}
		}

		public bool HasAnyPageMessages
		{
			get
			{
				if ((_pageErrors == null || _pageErrors.Count == 0) &&
					(_pageWarnings == null || _pageWarnings.Count == 0) &&
					(_pageSuccesses == null || _pageSuccesses.Count == 0))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		private readonly System.Collections.Generic.List<string> _toastErrors;

		public System.Collections.Generic.IReadOnlyList<string> ToastErrors
		{
			get
			{
				return _toastErrors;
			}
		}

		private readonly System.Collections.Generic.List<string> _toastWarnings;

		public System.Collections.Generic.IReadOnlyList<string> ToastWarnings
		{
			get
			{
				return _toastWarnings;
			}
		}

		private readonly System.Collections.Generic.List<string> _toastSuccesses;

		public System.Collections.Generic.IReadOnlyList<string> ToastSuccesses
		{
			get
			{
				return _toastSuccesses;
			}
		}

		public bool HasAnyToastMessages
		{
			get
			{
				if ((_toastErrors == null || _toastErrors.Count == 0) &&
					(_toastWarnings == null || _toastWarnings.Count == 0) &&
					(_toastSuccesses == null || _toastSuccesses.Count == 0))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		public bool AddPageError(string? message)
		{
			message =
				FixText(text: message);

			if (message == null)
			{
				return false;
			}

			if (_pageErrors.Contains(item: message))
			{
				return false;
			}

			_pageErrors.Add(item: message);

			return true;
		}

		public bool AddPageWarning(string? message)
		{
			message =
				FixText(text: message);

			if (message == null)
			{
				return false;
			}

			if (_pageWarnings.Contains(item: message))
			{
				return false;
			}

			_pageWarnings.Add(item: message);

			return true;
		}

		public bool AddPageSuccess(string? message)
		{
			message =
				FixText(text: message);

			if (message == null)
			{
				return false;
			}

			if (_pageSuccesses.Contains(item: message))
			{
				return false;
			}

			_pageSuccesses.Add(item: message);

			return true;
		}

		public bool AddToastError(string? message)
		{
			message =
				FixText(text: message);

			if (message == null)
			{
				return false;
			}

			if (_toastErrors.Contains(item: message))
			{
				return false;
			}

			_toastErrors.Add(item: message);

			return true;
		}

		public bool AddToastWarning(string? message)
		{
			message =
				FixText(text: message);

			if (message == null)
			{
				return false;
			}

			if (_toastWarnings.Contains(item: message))
			{
				return false;
			}

			_toastWarnings.Add(item: message);

			return true;
		}

		public bool AddToastSuccess(string? message)
		{
			message =
				FixText(text: message);

			if (message == null)
			{
				return false;
			}

			if (_toastSuccesses.Contains(item: message))
			{
				return false;
			}

			_toastSuccesses.Add(item: message);

			return true;
		}

		public bool AddMessage(MessageType type, string? message)
		{
			switch (type)
			{
				case MessageType.PageError:
				{
					return AddPageError(message: message);
				}

				case MessageType.PageWarning:
				{
					return AddPageWarning(message: message);
				}

				case MessageType.PageSuccess:
				{
					return AddPageSuccess(message: message);
				}

				case MessageType.ToastError:
				{
					return AddToastError(message: message);
				}

				case MessageType.ToastWarning:
				{
					return AddToastWarning(message: message);
				}

				case MessageType.ToastSuccess:
				{
					return AddToastSuccess(message: message);
				}

				default:
				{
					return false;
				}
			}
		}

		public void ClearPageErrors()
		{
			_pageErrors.Clear();
		}

		public void ClearPageWarnings()
		{
			_pageWarnings.Clear();
		}

		public void ClearPageSuccesses()
		{
			_pageSuccesses.Clear();
		}

		public void ClearPageMessages()
		{
			ClearPageErrors();
			ClearPageWarnings();
			ClearPageSuccesses();
		}

		public void ClearToastErrors()
		{
			_toastErrors.Clear();
		}

		public void ClearToastWarnings()
		{
			_toastWarnings.Clear();
		}

		public void ClearToastSuccesses()
		{
			_toastSuccesses.Clear();
		}

		public void ClearToastMessages()
		{
			ClearToastErrors();
			ClearToastWarnings();
			ClearToastSuccesses();
		}
	}
}
