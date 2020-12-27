using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Simply.CheckListMaster.BLL.Dto.CheckList;
using Simply.CheckListMaster.BLL.Enums;
using Simply.CheckListMaster.BLL.Mappers;
using Simply.CheckListMaster.BLL.MediatR.Commands.CheckList.Checks;
using Simply.CheckListMaster.BLL.MediatR.Queries.CheckList.Categories;
using Simply.CheckListMaster.BLL.MediatR.Queries.CheckList.Checks;
using Simply.CheckListMaster.PL.AspNet.Models.CheckLists;
using Simply.CheckListMaster.PL.AspNet.Models.CheckLists.Types;

namespace Simply.CheckListMaster.PL.AspNet.Controllers.CheckLists {

	[Authorize]
	public class CheckListController : Controller {
		private readonly IMediator _mediator;
		private readonly IMapper<CheckDto, CheckModel> _modelMapper;

		public CheckListController(IMediator mediator, IMapper<CheckDto, CheckModel> modelMapper) {
			Contract.Requires(mediator != null);
			Contract.Requires(modelMapper != null);

			_mediator = mediator;
			_modelMapper = modelMapper;
		}

		public async Task<IActionResult> Index(int? categoryId = null, int? stateId = null) {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var checkList = await _mediator.Send(new GetCheckListByUserId(userId, categoryId, stateId));

			await GetCategoriesToView(categoryId);
			GetStatesToView(stateId);

			var model = checkList
				.Select(c => _modelMapper.Map(c))
				.OrderByDescending(c => c.Id);

			return View("CheckList", model);
		}

		public async Task<IActionResult> Create() {
			await GetCategoriesToView();

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(
			[Bind("Id, Title, Discription, StartDate, EndDate, IsPriority, IsCompleted, Category, UserId")] CheckModel check
		) {
			if (!ModelState.IsValid) {
				return View(check);
			}

			check.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			await _mediator.Send(
				new AddCheck(_modelMapper.BackMap(check))
			);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int? id) {
			if (!id.HasValue) {
				return NotFound();
			}

			var check = await _mediator.Send(new GetCheck(id.Value));

			if (check == null) {
				return NotFound();
			}

			await GetCategoriesToView(check.Category?.Id);

			return View(_modelMapper.Map(check));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(
			[Bind("Id, Title, Discription, StartDate, EndDate, IsPriority, IsCompleted, Category, UserId")] CheckModel check
		) {
			if (!ModelState.IsValid) {
				ModelState.AddModelError("", "Incorrect fields");

				return View(check);
			}

			await _mediator.Send(
				new UpdateCheck(_modelMapper.BackMap(check))
			);

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id) {
			await _mediator.Send(new DeleteCheck(id));

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> Run(int id, string userId) {
			await _mediator.Send(new RunCheck(id, userId));

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> Complete(int id) {
			await _mediator.Send(new CompleteCheck(id));

			return RedirectToAction(nameof(Index));
		}

		private async Task GetCategoriesToView(int? selectedId = null) {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var dtoCategories = await _mediator.Send(new GetCategoriesByUserId(userId));

			var viewCategories = dtoCategories.Select(c => new CategoryModel {
				Id = c.Id,
				Name = c.Name
			});

			ViewData["Categories"] = new SelectList(viewCategories, "Id", "Name", viewCategories.FirstOrDefault(c => c.Id == selectedId));
		}

		private void GetStatesToView(int? selectedId = null) {
			var enumValues = Enum
				.GetValues(typeof(StateType))
				.Cast<StateType>()
				.Select(s => new { Id = (int) s, Name = s });
				
			ViewData["States"] = new SelectList(enumValues, "Id", "Name", enumValues.FirstOrDefault(c => c.Id == selectedId));
		}
	}
}
