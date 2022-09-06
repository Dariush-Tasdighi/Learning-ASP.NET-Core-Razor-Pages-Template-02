namespace Dtat.StateMachine.Abstractions
{
	public interface ITransition<T>
	{
		T Id { get; }

		T ToStateId { get; }

		T FromStateId { get; }

		int Code { get; }

		bool IsActive { get; }

		string ActionTitle { get; }

		string Description { get; }
	}
}
