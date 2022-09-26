namespace Domain.Seedwork
{
	public abstract class Entity : object,
		Dtat.Seedwork.Abstractions.IEntity<System.Guid>
	{
		#region Constructor(s)
		public Entity() : base()
		{
			Ordering = 10_000;

			InsertDateTime =
				Dtat.Utility.Now;

			Id =
				System.Guid.NewGuid();
		}
		#endregion /Constructor(s)

		#region Property(ies)

		#region Id Property
		/// <summary>
		/// شناسه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Id))]

		[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
			(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
		public System.Guid Id { get; protected set; }
		#endregion /Id Property

		#region Ordering Property
		/// <summary>
		/// چیدمان
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Ordering))]

		[System.ComponentModel.DataAnnotations.Range
			(minimum: 1, maximum: 100_000,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Range))]
		public int Ordering { get; set; }
		#endregion /Ordering Property

		#region InsertDateTime Property
		/// <summary>
		/// تاریخ و ساعت ایجاد
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.InsertDateTime))]

		[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
			(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
		public System.DateTime InsertDateTime { get; private set; }
		#endregion /InsertDateTime Property

		#endregion /Property(ies)
	}
}
