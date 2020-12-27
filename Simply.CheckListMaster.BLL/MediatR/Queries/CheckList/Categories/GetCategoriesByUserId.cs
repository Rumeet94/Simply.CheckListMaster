using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Simply.CheckListMaster.BLL.Dto.CheckList.Types;

namespace Simply.CheckListMaster.BLL.MediatR.Queries.CheckList.Categories {
	public class GetCategoriesByUserId : IQuery<IEnumerable<CategoryDto>> {
		public GetCategoriesByUserId(string userId) {
			Contract.Requires(!string.IsNullOrWhiteSpace(userId));

			UserId = userId;
		}

		public string UserId { get; }
	}
}
