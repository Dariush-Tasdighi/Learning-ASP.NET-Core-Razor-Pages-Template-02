namespace Infrastructure
{
	/// <summary>
	/// Version 3.0
	/// </summary>
	public abstract class BasePageModel :
		Microsoft.AspNetCore.Mvc.RazorPages.PageModel, Messages.IMessageHandler
	{
		public BasePageModel() : base()
		{
		}

		public bool AddPageError(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.PageError, message: message);
		}

		public bool AddPageWarning(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.PageWarning, message: message);
		}

		public bool AddPageSuccess(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.PageSuccess, message: message);
		}

		public bool AddToastError(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.ToastError, message: message);
		}

		public bool AddToastWarning(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.ToastWarning, message: message);
		}

		public bool AddToastSuccess(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.ToastSuccess, message: message);
		}

		public bool AddMessage(Messages.MessageType type, string? message)
		{
			return Messages.Utility.AddMessage
				(tempData: TempData, type: type, message: message);
		}
	}
}
