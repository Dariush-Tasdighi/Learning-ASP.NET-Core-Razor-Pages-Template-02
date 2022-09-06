namespace Dtat.Seedwork.Abstractions
{
	public interface IEntityHasLogicalDelete
	{
		bool IsDeleted { get; set; }
	}
}
