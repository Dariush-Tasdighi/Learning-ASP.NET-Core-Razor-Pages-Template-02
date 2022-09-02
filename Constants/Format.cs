namespace Constants;

public static class Format : object
{
	static Format()
	{
	}

	//public const string Integer = "#,##0";
	//public const string NullValue = "-----";

	//public const string Time = "HH:mm:ss";
	//public const string Date = "yyyy/MM/dd";
	//public const string DateTime = "yyyy/MM/dd - HH:mm:ss";

	public static string NullValue
	{
		get
		{
			//return null;
			//return string.Empty;
			return "-----";
		}
	}

	public static string Integer
	{
		get
		{
			return "#,##0";
		}
	}

	public static string Time
	{
		get
		{
			return "HH:mm:ss";
		}
	}

	public static string Date
	{
		get
		{
			return "yyyy/MM/dd";
		}
	}

	public static string DateTime
	{
		get
		{
			return $"{Date} - {Time}";
		}
	}
}
