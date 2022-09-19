namespace Dtat.Seedwork.Abstractions
{
	public interface IEntityHasUpdateDateTime
	{
		System.DateTime UpdateDateTime { get; }

		void SetUpdateDateTime();
	}
}
