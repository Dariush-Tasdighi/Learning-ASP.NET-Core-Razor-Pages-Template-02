namespace Dtat.Seedwork.Abstractions
{
	public interface IEntityHasIsDeleted
	{
		bool IsDeleted { get; set; }

		System.DateTime DeleteDateTime { get; }

		void SetDeleteDateTime();
	}
}
