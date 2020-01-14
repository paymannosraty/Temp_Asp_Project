using System.Linq;

namespace MY_MVC_APPLICATION.Controllers
{
	public partial class UsersController : Infrastructure.BaseController
	{
		public UsersController() : base()
		{

		}

		// GET: Users
		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Index()
		{
			var result =
				MyDatabaseContext.Users;

			return View(model:
				result
				.OrderBy(current => current.Username)
				.ToList());
		}


		// GET: Users/Details/5
		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Details(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			}

			Models.User foundedItem =
				MyDatabaseContext.Users
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (foundedItem == null)
			{
				return HttpNotFound();
			}
			return View(foundedItem);
		}

		// GET: Users/Create
		public virtual System.Web.Mvc.ViewResult Create()
		{
			var defaultAgeItem = new Models.User
			{
				Age = 27
			};

			var roles =
				MyDatabaseContext.Roles
				.Where(current => current.IsActive)
				.OrderBy(current => current.Name)
				.ToList()
				;

			ViewBag.RoleId =
				new System.Web.Mvc.SelectList(items: roles, dataValueField: nameof(Models.Role.Id), dataTextField: nameof(Models.Role.Name),
				selectedValue: null);

			return View(model: defaultAgeItem);
		}

		// POST: Users/Create
		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Create(Models.User user)
		{
			var foundedItem =
				MyDatabaseContext.Users
				.Where(current => current.Username.ToLower() == user.Username.ToLower())
				.FirstOrDefault();

			if (foundedItem != null)
			{
				string errorMessage =
					"This Username is already exists, please enter another one!";

				ModelState.AddModelError(key: string.Empty, errorMessage: errorMessage);
			}

			if (ModelState.IsValid)
			{

				MyDatabaseContext.Users.Add(user);
				MyDatabaseContext.SaveChanges();
				return RedirectToAction(MVC.Users.Index());
			}
			/******************************************************************************************/
			var roles =
				MyDatabaseContext.Roles
				.Where(current => current.IsActive)
				.OrderBy(current => current.Name)
				.ToList()
				;

			ViewBag.RoleId =
				new System.Web.Mvc.SelectList(items: roles, dataValueField: nameof(Models.Role.Id), dataTextField: nameof(Models.Role.Name),
				selectedValue: user.RoleId);
			/******************************************************************************************/
			return View(model: user);
		}

		// GET: Users/Edit/5
		public virtual System.Web.Mvc.ActionResult Edit(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			}

			var foundedItem =
				MyDatabaseContext.Users
				.Where(current => current.Id == id.Value)
				.FirstOrDefault()
				;

			if (foundedItem == null)
			{
				return HttpNotFound();
			}

			/******************************************************************************************/
			var roles =
				MyDatabaseContext.Roles
				.Where(current => current.IsActive)
				.OrderBy(current => current.Name)
				.ToList()
				;

			ViewBag.RoleId =
				new System.Web.Mvc.SelectList(items: roles, dataValueField: nameof(Models.Role.Id), dataTextField: nameof(Models.Role.Name),
				selectedValue: foundedItem.RoleId);
			/******************************************************************************************/

			return View(model: foundedItem);
		}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Edit(Models.User user)
		{
			var foundedItem =
				MyDatabaseContext.Users
				.Where(current => current.Username.ToLower() == user.Username.ToLower())
				.Where(current => current.Id != user.Id)
				.FirstOrDefault();

			if (foundedItem != null)
			{
				string errorMessage =
					"This Username is already exists, please enter another one!";

				ModelState.AddModelError(key: string.Empty, errorMessage: errorMessage);
			}
			var originalItem =
				MyDatabaseContext.Users
				.Where(current => current.Id == user.Id)
				.FirstOrDefault()
				;

			if (originalItem == null)
			{
				return HttpNotFound();
			}

			if (ModelState.IsValid)
			{
				originalItem.Age = user.Age;
				originalItem.RoleId = user.RoleId;
				originalItem.FullName = user.FullName;
				originalItem.IsActive = user.IsActive;
				originalItem.Password = user.Password;
				originalItem.Username = user.Username;
				originalItem.Description = user.Description;

				MyDatabaseContext.SaveChanges();
				return RedirectToAction(MVC.Users.Index());
			}

			/******************************************************************************************/
			var roles =
				MyDatabaseContext.Roles
				.Where(current => current.IsActive)
				.OrderBy(current => current.Name)
				.ToList()
				;

			ViewBag.RoleId =
				new System.Web.Mvc.SelectList(items: roles, dataValueField: nameof(Models.Role.Id), dataTextField: nameof(Models.Role.Name),
				selectedValue: user.RoleId);
			/******************************************************************************************/

			return View(model: user);
		}

		// GET: Users/Delete/5
		public virtual System.Web.Mvc.ActionResult Delete(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			}

			var foundedItem =
				MyDatabaseContext.Users
				.Where(current => current.Id == id.Value)
				.FirstOrDefault()
				;

			if (foundedItem == null)
			{
				return HttpNotFound();
			}

			return View(model: foundedItem);
		}

		// POST: Users/Delete/5
		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ActionName("Delete")]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult DeleteConfirmed(System.Guid id)
		{
			var foundedItem =
				MyDatabaseContext.Users
				.Where(current => current.Id == id)
				.FirstOrDefault()
				;

			if (foundedItem == null)
			{
				return HttpNotFound();
			}

			MyDatabaseContext.Users.Remove(foundedItem);

			MyDatabaseContext.SaveChanges();

			return RedirectToAction(MVC.Users.Index());
		}
	}
}
