namespace Infrastructure.Messages
{
	/// <summary>
	/// Version 3.0
	/// </summary>
	public enum MessageType : byte
	{
		PageError,
		PageWarning,
		PageSuccess,

		ToastError,
		ToastWarning,
		ToastSuccess,
	}
}
