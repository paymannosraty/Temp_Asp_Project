namespace MY_MVC_APPLICATION.Controllers
{
	public partial class HomeController : Infrastructure.BaseController
	{
		public HomeController() : base()
		{
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Index()
		{
			return View();
		}
	}
}
