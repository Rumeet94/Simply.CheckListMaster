using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Simply.CheckListMaster.BLL.Dto.CheckList;

namespace Simply.CheckListMaster.BLL.MediatR.Queries.CheckList.Checks {
	public class GetCheckListByUserId : IQuery<IEnumerable<CheckDto>> {
		public GetCheckListByUserId(string userId, int? categoryId, int? stateId) {
			Contract.Requires(!string.IsNullOrWhiteSpace(userId));

			UserId = userId;
			CategoryId = categoryId;
			StateId = stateId;
		}

		public string UserId { get; }

		public int? CategoryId { get; }

		public int? StateId { get; }
	}
}
