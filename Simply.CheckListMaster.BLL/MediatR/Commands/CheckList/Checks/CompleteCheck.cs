using System.Diagnostics.Contracts;

namespace Simply.CheckListMaster.BLL.MediatR.Commands.CheckList.Checks {
	public class CompleteCheck : ICommand {
		public CompleteCheck(int id) {
			Contract.Requires(id > 0);

			Id = id;
		}

		public int Id { get; }
	}
}
