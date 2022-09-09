namespace Dtat.StateMachine.Abstractions
{
	public interface IState<T>
	{
		T Id { get; }

		T StateMachineId { get; }

		int Code { get; }

		bool IsActive { get; }

		bool IsFinal { get; }

		bool IsInitial { get; }

		string Icon { get; }

		string Color { get; }

		string Title { get; }

		string Description { get; }
	}
}
