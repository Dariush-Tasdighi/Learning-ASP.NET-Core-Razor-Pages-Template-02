namespace ViewModels.Shared;

public class PaginationViewModel : object
{
	public PaginationViewModel() : base()
	{
	}

	public int PageSize { get; set; }

	public int TotalCount { get; set; }

	public int PageNumber { get; set; }

	public int PageCount
	{
		get
		{
			int result =
				System.Convert.ToInt32(System.Math.Ceiling
				(System.Convert.ToDouble(TotalCount) / PageSize));

			return result;
		}
	}
}
