using System.Diagnostics.Contracts;

namespace Simply.CheckListMaster.BLL.MediatR.Commands.CheckList.Categories {
	public class UpdateCategory : ICommand {
		public UpdateCategory(int id, string name) {
			Contract.Requires(id > 0);
			Contract.Requires(!string.IsNullOrWhiteSpace(name));

			Id = id;
			Name = name;
		}

		public int Id { get; }

		public string Name { get; }
	}
}
