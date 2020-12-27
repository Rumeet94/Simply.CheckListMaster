using System.Diagnostics.Contracts;

using Simply.CheckListMaster.BLL.Dto.CheckList;

namespace Simply.CheckListMaster.BLL.MediatR.Queries.CheckList.Checks {
	public class GetCheck : IQuery<CheckDto> {
		public GetCheck(int id) {
			Contract.Requires(id > 0);

			Id = id;
		}

		public int Id { get; }
	}
}
