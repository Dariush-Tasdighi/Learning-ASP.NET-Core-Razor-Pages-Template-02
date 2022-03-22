namespace Domain.SeedWork
{
	public interface IEntityHasIsSystemic
	{
		/// <summary>
		/// در صورت مثبت بدون این فیلد
		/// بدان معنا است که رکورد به صورت سیستمی ایجاد شده
		/// و کاربر به صورت مستقیم اقدام به ایجاد آن نکرده است
		/// </summary>
		bool IsSystemic { get; set; }
	}
}
