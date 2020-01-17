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
		
		[System.ComponentModel.DataAnnotations.DisplayFormat
			(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd, yyyy/MM/dd}")]

		public System.DateTime Date { get; set; }
		// **********

		// **********
		public System.TimeSpan StartTime { get; set; }
		// **********

		// **********
		public System.TimeSpan EndTime { get; set; }
		// **********

		// **********
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
