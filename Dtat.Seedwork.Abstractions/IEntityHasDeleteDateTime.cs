namespace Dtat.Seedwork.Abstractions
{
	public interface IEntityHasDeleteDateTime
	{
		System.DateTime DeleteDateTime { get; }

		void SetDeleteDateTime();
	}
}
