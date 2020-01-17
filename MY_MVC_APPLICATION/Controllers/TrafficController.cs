using System.Linq;

namespace MY_MVC_APPLICATION.Controllers
{
	public partial class TrafficsController : Infrastructure.BaseController
	{
		public TrafficsController() : base()
		{

		}

		// GET: Traffics
		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Index()
		{
			var result =
				MyDatabaseContext.Traffics;
			
			return View(model:
				result
				.OrderBy(current => current.User.Username)
				.ToList());
		}

		// GET: Traffics/Details/5
		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Details(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			}

			Models.Traffic foundedItem =
				MyDatabaseContext.Traffics
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (foundedItem == null)
			{
				return HttpNotFound();
			}
			return View(foundedItem);
		}

		// GET: Traffics/Create
		public virtual System.Web.Mvc.ViewResult Create()
		{
			var users =
				MyDatabaseContext.Users
				.Where(current => current.IsActive)
				.OrderBy(current => current.Username)
				.ToList()
				;

			ViewBag.UserId =
				new System.Web.Mvc.SelectList(items: users, dataValueField: nameof(Models.User.Id), dataTextField: nameof(Models.User.Username),
				selectedValue: null);

			return View();
		}

		// POST: Traffics/Create
		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Create(Models.Traffic traffic)
		{

			if (traffic.EndTime<traffic.StartTime)
			{
				string errorMessage =
					"EndTime Cannot be Smaller Than StartTime";

				ModelState.AddModelError(key: string.Empty, errorMessage: errorMessage);
			}

			if (ModelState.IsValid)
			{
				
				MyDatabaseContext.Traffics.Add(traffic);
				MyDatabaseContext.SaveChanges();
				return RedirectToAction(MVC.Traffics.Index());
			}
			/******************************************************************************************/
			var users =
				MyDatabaseContext.Users
				.Where(current => current.IsActive)
				.OrderBy(current => current.Username)
				.ToList()
				;

			ViewBag.UserId =
				new System.Web.Mvc.SelectList(items: users, dataValueField: nameof(Models.User.Id), dataTextField: nameof(Models.User.Username),
				selectedValue: traffic.UserId);
			/******************************************************************************************/
			return View(model: traffic);
		}

		// GET: Traffics/Edit/5
		public virtual System.Web.Mvc.ActionResult Edit(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			}

			var foundedItem =
				MyDatabaseContext.Traffics
				.Where(current => current.Id == id.Value)
				.FirstOrDefault()
				;

			if (foundedItem == null)
			{
				return HttpNotFound();
			}

			/******************************************************************************************/
			var users =
				MyDatabaseContext.Users
				.Where(current => current.IsActive)
				.OrderBy(current => current.Username)
				.ToList()
				;

			ViewBag.UserId =
				new System.Web.Mvc.SelectList(items: users, dataValueField: nameof(Models.User.Id), dataTextField: nameof(Models.User.Username),
				selectedValue: foundedItem.UserId);
			/******************************************************************************************/

			return View(model: foundedItem);
		}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Edit(Models.Traffic traffic)
		{

			var originalItem =
				MyDatabaseContext.Traffics
				.Where(current => current.Id == traffic.Id)
				.FirstOrDefault()
				;

			if (originalItem == null)
			{
				return HttpNotFound();
			}

			if (ModelState.IsValid)
			{
				originalItem.Date = traffic.Date;
				originalItem.UserId = traffic.UserId;
				originalItem.EndTime = traffic.EndTime;
				originalItem.Duration = traffic.Duration;
				originalItem.StartTime = traffic.StartTime;

				MyDatabaseContext.SaveChanges();
				return RedirectToAction(MVC.Traffics.Index());
			}

			/******************************************************************************************/
			var users =
				MyDatabaseContext.Users
				.Where(current => current.IsActive)
				.OrderBy(current => current.Username)
				.ToList()
				;

			ViewBag.UserId =
				new System.Web.Mvc.SelectList(items: users, dataValueField: nameof(Models.User.Id), dataTextField: nameof(Models.User.Username),
				selectedValue: traffic.UserId);
			/******************************************************************************************/

			return View(model: traffic);
		}

		// GET: Traffics/Delete/5
		public virtual System.Web.Mvc.ActionResult Delete(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return new System.Web.Mvc
					.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			}

			var foundedItem =
				MyDatabaseContext.Traffics
				.Where(current => current.Id == id.Value)
				.FirstOrDefault()
				;

			if (foundedItem == null)
			{
				return HttpNotFound();
			}

			return View(model: foundedItem);
		}

		// POST: Traffics/Delete/5
		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ActionName("Delete")]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult DeleteConfirmed(System.Guid id)
		{
			var foundedItem =
				MyDatabaseContext.Traffics
				.Where(current => current.Id == id)
				.FirstOrDefault()
				;

			if (foundedItem == null)
			{
				return HttpNotFound();
			}

			MyDatabaseContext.Traffics.Remove(foundedItem);

			MyDatabaseContext.SaveChanges();

			return RedirectToAction(MVC.Traffics.Index());
		}
	}
}
