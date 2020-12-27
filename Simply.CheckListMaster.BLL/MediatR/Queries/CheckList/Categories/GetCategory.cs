using System.Diagnostics.Contracts;

using Simply.CheckListMaster.BLL.Dto.CheckList.Types;

namespace Simply.CheckListMaster.BLL.MediatR.Queries.CheckList.Categories {
	public class GetCategory : IQuery<CategoryDto> {
		public GetCategory(int id) {
			Contract.Requires(id > 0);

			Id = id;
		}

		public int Id { get; }
	}
}
