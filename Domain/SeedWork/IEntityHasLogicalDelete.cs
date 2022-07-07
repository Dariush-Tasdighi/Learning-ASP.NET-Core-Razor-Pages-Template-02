namespace Domain.SeedWork
{
	public interface IEntityHasLogicalDelete
	{
		bool IsDeleted { get; set; }
	}
}
