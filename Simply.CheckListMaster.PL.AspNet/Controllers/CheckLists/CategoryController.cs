using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Simply.CheckListMaster.BLL.MediatR.Commands.CheckList.Categories;
using Simply.CheckListMaster.BLL.MediatR.Queries.CheckList.Categories;
using Simply.CheckListMaster.PL.AspNet.Models.CheckLists.Types;

namespace Simply.CheckListMaster.PL.AspNet.Controllers.CheckLists {

	[Authorize]
	public class CategoryController : Controller {
		private readonly IMediator _mediator;
		private readonly UserManager<IdentityUser> _userManager;

		public CategoryController(IMediator mediator, UserManager<IdentityUser> userManager) {
			Contract.Requires(mediator != null);
			Contract.Requires(userManager != null);

			_mediator = mediator;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index() {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var categories = await _mediator.Send(new GetCategoriesByUserId(userId));

			var model = categories.Select(c =>
				new CategoryModel {
					Id = c.Id,
					Name = c.Name
			});

			return View(model);
		}

		public IActionResult Create() =>
			View();

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id, Name")] CategoryModel category) {
			if (!ModelState.IsValid) {
				ModelState.AddModelError("Name", "Incorrect name field");

				return View(category);
			}

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			await _mediator.Send(new AddCategory(userId, category.Name));

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int? id) {
			if (!id.HasValue) {
				return NotFound();
			}

			var category = await _mediator.Send(new GetCategory(id.Value));

			if (category == null) {
				return NotFound();
			}

			var model = new CategoryModel {
				Id = category.Id,
				Name = category.Name
			};

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit([Bind("Id, Name")] CategoryModel category) {
			if (!ModelState.IsValid) {
				ModelState.AddModelError("Name", "Incorrect name field");

				return View(category);
			}

			await _mediator.Send(new UpdateCategory(category.Id, category.Name));

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id) {
			await _mediator.Send(new DeleteCategory(id));

			return RedirectToAction(nameof(Index));
		}
	}
}
