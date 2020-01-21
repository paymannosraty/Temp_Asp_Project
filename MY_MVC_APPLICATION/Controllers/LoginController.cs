using System.Linq;

namespace MY_MVC_APPLICATION.Controllers
{
	public partial class LoginController : Infrastructure.BaseController
	{
		public LoginController() : base()
		{
		}

		// GET: Login
		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Index()
		{
			return View();
		}

		[System.Web.Mvc.HttpPost]
		public virtual System.Web.Mvc.ActionResult Index(Models.User user)
		{
			var foundedItem =
				MyDatabaseContext.Users
				.Where(current => string.Compare(current.Username, user.Username, false) == 0)
				.FirstOrDefault();

			if (foundedItem != null)
			{
				if (string.Compare(foundedItem.Password, user.Password, false) == 0)
				{
					Infrastructure.Utility.AuthenticatedUser = foundedItem;
					return RedirectToAction(MVC.Home.Index());
				}
			}

			string errorMessage =
				"UserName Or Password is/are Wrong!";

			ModelState.AddModelError(key: string.Empty, errorMessage: errorMessage);
	
			return View(model: user);
		}
	}
}
