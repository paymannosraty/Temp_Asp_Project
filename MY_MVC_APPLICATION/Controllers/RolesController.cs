using System.Linq;

namespace MY_MVC_APPLICATION.Controllers
{
	public partial class RolesController : Infrastructure.BaseController
	{
		public RolesController() : base()
		{

		}

		// GET: Roles
		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Index()
		{
			var result =
				MyDatabaseContext.Roles;

			return View(model:
				result
				.OrderBy(current => current.Name)
				.ToList());
		}

		// GET: Roles/Details/5
		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Details(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			}

			Models.Role foundedItem =
				MyDatabaseContext.Roles
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (foundedItem == null)
			{
				return HttpNotFound();
			}
			return View(foundedItem);
		}

		// GET: Roles/Create
		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Create()
		{
			return View();
		}

		// POST: Roles/Create
		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]

		public virtual System.Web.Mvc.ActionResult Create([System.Web.Mvc.Bind(Include = "Id,IsActive,Name")] Models.Role role)
		{

			if (ModelState.IsValid)
			{
				MyDatabaseContext.Roles.Add(role);
				MyDatabaseContext.SaveChanges();
				return RedirectToAction(MVC.Roles.Index());
			}

			return View(role);
		}

		// GET: Roles/Edit/5
		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Edit(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return new System.Web.Mvc.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			}

			var foundedItem =
				MyDatabaseContext.Roles
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (foundedItem == null)
			{
				return HttpNotFound();
			}
			return View(foundedItem);
		}

		// POST: Roles/Edit/5
		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Edit([System.Web.Mvc.Bind(Include = "Id,IsActive,Name")] Models.Role role)
		{
			Models.Role originalrole =
				MyDatabaseContext.Roles
				.Where(current => current.Id == role.Id)
				.FirstOrDefault();

			if (originalrole == null)
			{
				return HttpNotFound();
			}

			if (ModelState.IsValid)
			{
				originalrole.Name = role.Name;
				originalrole.IsActive = role.IsActive;

				MyDatabaseContext.SaveChanges();

				return RedirectToAction(MVC.Roles.Index());
			}
			return View(role);
		}

		// GET: Roles/Delete/5
		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Delete(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			}

			Models.Role role =
				MyDatabaseContext.Roles
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (role == null)
			{
				return HttpNotFound();
			}
			return View(role);
		}

		// POST: Roles/Delete/5
		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ActionName("Delete")]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult DeleteConfirmed(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			}

			Models.Role role =
				MyDatabaseContext.Roles
				.Where(current => current.Id == id)
				.FirstOrDefault();

			if (role == null)
			{
				return HttpNotFound();
			}

			MyDatabaseContext.Roles.Remove(role);

			MyDatabaseContext.SaveChanges();

			return RedirectToAction(MVC.Roles.Index());
		}
	}
}
