namespace Domain.Seedwork
{
	public static class Utility
	{
		static Utility()
		{
		}

		public static System.DateTime Now
		{
			get
			{
				var result =
					System.DateTime.Now;

				//var result =
				//	System.DateTime.UtcNow;

				return result;
			}
		}
	}
}
