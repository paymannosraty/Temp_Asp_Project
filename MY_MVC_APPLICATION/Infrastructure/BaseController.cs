namespace Infrastructure
{
	public class BaseController : System.Web.Mvc.Controller
	{
		public BaseController() : base()
		{

		}

		private Models.DatabaseContext myDatabaseContext;

		protected Models.DatabaseContext MyDatabaseContext
		{
			get
			{
				if (myDatabaseContext == null)
				{
					myDatabaseContext = new Models.DatabaseContext();
				}
				return myDatabaseContext;
			}
			private set
			{
				myDatabaseContext = value;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (myDatabaseContext != null)
				{
					myDatabaseContext.Dispose();
					myDatabaseContext = null;
				}
			}
			base.Dispose(disposing);
		}

	}
}
