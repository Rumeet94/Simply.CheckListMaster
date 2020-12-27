using System.Diagnostics;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

using Simply.CheckListMaster.PL.AspNet.Models;

namespace Simply.CheckListMaster.PL.AspNet.Controllers {
	public class HomeController : Controller {
		public IActionResult Index() {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (!string.IsNullOrWhiteSpace(userId)) {
				return RedirectToAction("Index", "CheckList");
			}

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
