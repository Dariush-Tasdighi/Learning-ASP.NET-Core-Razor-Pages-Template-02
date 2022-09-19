namespace Dtat.StateMachine.Abstractions
{
	public interface ITransition<T>
	{
		T Id { get; }

		T ToStateId { get; }

		T FromStateId { get; }

		T StateMachineId { get; }

		bool IsActive { get; }

		/// <summary>
		/// New
		/// </summary>
		bool IsSystemic { get; set; }

		/// <summary>
		/// New
		/// </summary>
		bool IsCommentRequired { get; }

		string Icon { get; }

		string Color { get; }

		string ActionTitle { get; }

		string Description { get; }
	}
}
