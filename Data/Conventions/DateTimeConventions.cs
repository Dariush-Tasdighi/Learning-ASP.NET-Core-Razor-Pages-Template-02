namespace Data.Conventions;

internal static class DateTimeConventions : object
{
	static DateTimeConventions()
	{
	}

	/// <summary>
	/// Converts <see cref="System.DDateOnly" /> to <see cref="System.DDateTime"/> and vice versa.
	/// </summary>
	internal class DateOnlyConverter :
		Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<System.DateOnly, System.DateTime>
	{
		/// <summary>
		/// Creates a new instance of this converter.
		/// </summary>
		public DateOnlyConverter() : base
			(current => current.ToDateTime(System.TimeOnly.MinValue),
			current => System.DateOnly.FromDateTime(current))
		{
		}
	}

	/// <summary>
	/// Converts <see cref="System.DateOnly?" /> to <see cref="System.DDateTime?"/> and vice versa.
	/// </summary>
	internal class NullableDateOnlyConverter :
		Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<System.DateOnly?, System.DateTime?>
	{
		/// <summary>
		/// Creates a new instance of this converter.
		/// </summary>
		public NullableDateOnlyConverter() : base
			(current => current == null ? null : new System.DateTime?(current.Value.ToDateTime(System.TimeOnly.MinValue)),
			current => current == null ? null : new System.DateOnly?(System.DateOnly.FromDateTime(current.Value)))
		{
		}
	}
}
