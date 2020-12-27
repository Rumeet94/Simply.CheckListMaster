using System.Diagnostics.Contracts;

namespace Simply.CheckListMaster.BLL.MediatR.Commands.CheckList.Categories {
	public class AddCategory : ICommand {
		public AddCategory(string userId, string name) {
			Contract.Requires(!string.IsNullOrWhiteSpace(userId));
			Contract.Requires(!string.IsNullOrWhiteSpace(name));

			UserId = userId;
			Name = name;
		}

		public string UserId { get; }

		public string Name { get; }
	}
}
