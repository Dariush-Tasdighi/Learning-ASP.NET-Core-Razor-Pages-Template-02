namespace Dtat.StateMachine.Abstractions
{
	public interface ITransition<T>
	{
		T Id { get; }

		T ToStateId { get; }

		T FromStateId { get; }

		T StateMachineId { get; }

		int Code { get; }

		bool IsActive { get; }

		string Icon { get; }

		string Color { get; }

		string ActionTitle { get; }

		string Description { get; }
	}
}
