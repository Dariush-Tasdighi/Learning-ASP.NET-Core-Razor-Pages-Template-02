namespace Domain.SeedWork
{
	public interface IEntityHasIsUpdatable : IEntityHasUpdateDateTime
	{
		bool IsUpdatable { get; set; }
	}
}
