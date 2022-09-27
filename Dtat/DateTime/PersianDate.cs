namespace Dtat.DateTime
{
	public class PersianDate : object
	{
		static PersianDate()
		{
			PersianCalendar =
				new System.Globalization.PersianCalendar();
		}

		protected static System.Globalization.PersianCalendar PersianCalendar { get; }

		public static string ConvertToDateString(System.DateTime dateTime)
		{
			var persianDate =
				new PersianDate(dateTime: dateTime);

			var result =
				persianDate.ToString();

			return result;
		}

		public PersianDate(System.DateTime dateTime) : base()
		{
			DateTime = dateTime;

			Day =
				PersianCalendar.GetDayOfMonth(time: dateTime);

			Month =
				PersianCalendar.GetMonth(time: dateTime);

			Year =
				PersianCalendar.GetYear(time: dateTime);
		}

		public int Day { get; }

		public int Month { get; }

		public int Year { get; }

		public System.DateTime DateTime { get; }

		public override string ToString()
		{
			var dayString =
				Day.ToString()
				.PadLeft(totalWidth: 2, paddingChar: '0');

			var monthString =
				Month.ToString()
				.PadLeft(totalWidth: 2, paddingChar: '0');

			var result =
				$"{Year}/{monthString}/{dayString}";

			return result;
		}
	}
}
