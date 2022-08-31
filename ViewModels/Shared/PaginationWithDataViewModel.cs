namespace ViewModels.Shared;

public class PaginationWithDataViewModel<T> : object
{
	public PaginationWithDataViewModel() : base()
	{
		PageInformation = new();

		Data = new System.Collections.Generic.List<T>();
	}

	public PaginationViewModel PageInformation { get; set; }

	public System.Collections.Generic.IList<T> Data { get; set; }
}
