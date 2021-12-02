using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BachelorWeb.Controllers
{
	public class LoginController : Controller
	{
		Learn_BasicEntities db = new Learn_BasicEntities();

		// GET: Login
		public ActionResult Index()
		{
			ViewBag.Message = "Your Login page.";

			return View();
		}

		[HttpPost]
		public ActionResult BTNLogin(String username, String password)
		{

			if (username != null && password != null)
			{
				var validation = from l in db.Lærer
								 where l.Email == username && l.Password == password
								 select new
								 {
									 ID = l.ID,
									 Navn = l.Fornavn
								 };

				if (validation.Count() == 1)
				{
					Session["Status"] = "LoggedIn";
					Session.Add("Userid", validation.First().ID);
					Session.Add("Navn", validation.First().Navn);
					ViewBag.Message = "Logged in";
					return RedirectToAction("Index", "Home", null);
				}
				else
				{
					ViewBag.Message = "Wrong login info";
					ViewBag.LastInput = username;
					return View("Index");
				}
			}
			else
			{
				ViewBag.Message = "Wrong login info";
				ViewBag.LastInput = username;
				return View("Index");
			}
		}

		public ActionResult Logout()
		{
			Session["Status"] = null;
			Session.Remove("Userid");
			Session.Remove("Navn");
			ViewBag.Message = "Logged out";
			return RedirectToAction("Index", "Home", null);

		}
	}
}