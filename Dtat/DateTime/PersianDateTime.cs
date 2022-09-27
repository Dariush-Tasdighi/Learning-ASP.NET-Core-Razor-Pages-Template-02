namespace Dtat.DateTime
{
	public class PersianDateTime : PersianDate
	{
		static PersianDateTime()
		{
		}

		public static string ConvertToDateTimeString(System.DateTime dateTime)
		{
			var persianDateTime =
				new PersianDateTime(dateTime: dateTime);

			var result =
				persianDateTime.ToString();

			return result;
		}

		public PersianDateTime(System.DateTime dateTime) : base(dateTime: dateTime)
		{
			Hour = dateTime.Hour;
			Minute = dateTime.Minute;
			Second = dateTime.Second;
		}

		public int Hour { get; }

		public int Minute { get; }

		public int Second { get; }

		public override string ToString()
		{
			var hourString =
				Hour.ToString()
				.PadLeft(totalWidth: 2, paddingChar: '0');

			var minuteString =
				Minute.ToString()
				.PadLeft(totalWidth: 2, paddingChar: '0');

			var secondString =
				Second.ToString()
				.PadLeft(totalWidth: 2, paddingChar: '0');

			var result =
				$"{base.ToString()} - {hourString}:{minuteString}:{secondString}";

			return result;
		}
	}
}
