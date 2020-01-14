namespace Models
{
	public class Traffic : BaseEntity
	{
		public Traffic() : base()
		{
		}

		// **********
		// **********
		// **********
		public virtual User User { get; set; }
		// **********

		// **********
		public System.Guid UserId { get; set; }
		// **********
		// **********
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false)]

		public System.DateTime Date { get; set; }
		// **********

		// **********
		public System.DateTime StartTime { get; set; }
		// **********

		// **********
		public System.DateTime EndTime { get; set; }
		// **********
		// **********
		//public System.TimeSpan Duration { get; set; }
		private System.TimeSpan duration;

		public System.TimeSpan Duration
		{
			get
			{
				return duration;
			}
			set
			{
				duration = EndTime - StartTime;
			}
		}

		// **********

	}
}
