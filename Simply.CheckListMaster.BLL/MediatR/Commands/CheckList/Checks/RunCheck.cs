using System.Diagnostics.Contracts;

namespace Simply.CheckListMaster.BLL.MediatR.Commands.CheckList.Checks {
	public class RunCheck : ICommand {
		public RunCheck(int id, string userId) {
			Contract.Requires(id > 0);
			Contract.Requires(!string.IsNullOrWhiteSpace(userId));

			Id = id;
			UserId = userId;
		}

		public int Id { get; }

		public string UserId { get; }
	}
}
