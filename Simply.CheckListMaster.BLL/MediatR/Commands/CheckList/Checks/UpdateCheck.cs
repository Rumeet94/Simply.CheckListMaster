using System;
using System.Diagnostics.Contracts;

using Simply.CheckListMaster.BLL.Dto.CheckList;

namespace Simply.CheckListMaster.BLL.MediatR.Commands.CheckList.Checks {
	public class UpdateCheck : ICommand {
		public UpdateCheck(CheckDto check) {
			Contract.Requires(check != null);

			Id = check.Id;
			Title = check.Title;
			Discription = check.Discription;
			StartDate = check.StartDate;
			EndDate = check.EndDate;
			CategoryId = check.Category != null
				? check.Category.Id as int?
				: null;
		}

		public int Id { get; }

		public string Title { get; }

		public string Discription { get; }

		public DateTime? StartDate { get; }

		public DateTime? EndDate { get; }

		public bool IsPriority { get; }

		public bool IsCompleted { get; }

		public int? CategoryId { get; }
	}
}
