using System;
using System.Diagnostics.Contracts;

using Simply.CheckListMaster.BLL.Dto.CheckList;

namespace Simply.CheckListMaster.BLL.MediatR.Commands.CheckList.Checks {
	public class AddCheck : ICommand {
		public AddCheck(CheckDto check) {
			Contract.Requires(check != null);

			Title = check.Title;
			Discription = check.Discription;
			StartDate = check.StartDate;
			EndDate = check.EndDate;
			UserId = check.UserId;
			CategoryId = check.Category != null
				? check.Category.Id as int?
				: null;
		}

		public string Title { get; }

		public string Discription { get; }

		public DateTime? StartDate { get; }

		public DateTime? EndDate { get; }

		public bool IsPriority { get; }

		public int? CategoryId { get; }

		public string UserId { get; }

		public bool IsCompleted { get; }
	}
}
