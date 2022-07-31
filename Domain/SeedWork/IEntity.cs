namespace Domain.SeedWork
{
	public interface IEntity
	{
		// **********
		public System.Guid Id { get; }
		// **********

		// **********
		public int Ordering { get; set; }
		// **********

		// **********
		public System.DateTime InsertDateTime { get; }
		// **********
	}
}
