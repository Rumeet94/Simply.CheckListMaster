using System;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Simply.CheckListMaster.BLL.Exceptions;
using Simply.CheckListMaster.BLL.MediatR.Commands.CheckList.Categories;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList.Types;
using Simply.CheckListMaster.DLL.EntityFramework.Repositories;

namespace Simply.CheckListMaster.BLL.MediatR.Commands.Handlers.CheckList.Categories {
	public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategory> {
		private readonly IRepository<Category> _repository;

		public UpdateCategoryCommandHandler(IRepository<Category> repository) {
			Contract.Requires(repository != null);

			_repository = repository;
		}

		public async Task<Unit> Handle(UpdateCategory request, CancellationToken cancellationToken) {
			try {
				var category = _repository.GetSingle(request.Id);

				category.Name = request.Name;

				await _repository.UpdateAsync(category);

				return Unit.Value;
			}
			catch (Exception e) {
				throw new MediatorException(e.Message);
			}
		}
	}
}
