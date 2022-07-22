namespace Domain.SeedWork
{
	public interface IEntity
	{
		// **********
		public System.Guid Id { get; }
		// **********

		// **********
		public uint Ordering { get; set; }
		// **********

		// **********
		public System.DateTime InsertDateTime { get; }
		// **********
	}
}
