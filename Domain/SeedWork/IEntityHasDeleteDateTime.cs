namespace Domain.SeedWork
{
	public interface IEntityHasDeleteDateTime
	{
		System.DateTime DeleteDateTime { get; }

		void SetDeleteDateTime();
	}
}
