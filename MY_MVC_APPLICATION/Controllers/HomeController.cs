using System.Linq;

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
			///در صورتی که برانامه برای بار اول اجرا می شود
			///به صورت پیش فرض درج می گردد User و یک role یک
			var anyRole =
							MyDatabaseContext.Roles
							.Any();
			if (anyRole == false)
			{
				try
				{
					//**** Role
					Models.Role initRole =
					new Models.Role
					{
						Name = "Admin",
						IsActive = true,
					};

					MyDatabaseContext.Roles.Add(initRole);

					//**** User
					Models.User initUser =
						new Models.User
						{
							Age = 27,
							IsActive = true,
							RoleId = initRole.Id,
							Password = "123456789",
							Description = "Nothing",
							Username = "PaymanNosraty",
							FullName = "Payman Nosraty",
						};

					MyDatabaseContext.Users.Add(initUser);

					MyDatabaseContext.SaveChanges();
				}
				catch (System.Exception)
				{
					throw;
				}

			}

			return View();
		}
	}
}
