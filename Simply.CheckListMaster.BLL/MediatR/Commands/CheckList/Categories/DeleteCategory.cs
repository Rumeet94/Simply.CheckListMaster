using System.Diagnostics.Contracts;

namespace Simply.CheckListMaster.BLL.MediatR.Commands.CheckList.Categories {
	public class DeleteCategory : ICommand {
		public DeleteCategory(int categoryId) {
			Contract.Requires(categoryId > 0);

			Id = categoryId;
		}

		public int Id { get; }
	}
}
