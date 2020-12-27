using System;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Simply.CheckListMaster.BLL.Exceptions;
using Simply.CheckListMaster.BLL.MediatR.Commands.CheckList.Checks;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList;
using Simply.CheckListMaster.DLL.EntityFramework.Repositories;

namespace Simply.CheckListMaster.BLL.MediatR.Commands.Handlers.CheckList.Checks {
	public class AddCheckCommandHandler : ICommandHandler<AddCheck> {
		private readonly IRepository<Check> _repository;

		public AddCheckCommandHandler(IRepository<Check> repository) {
			Contract.Requires(repository != null);

			_repository = repository;
		}

		public async Task<Unit> Handle(AddCheck request, CancellationToken cancellationToken) {
			try {
				var category = Map(request);

				await _repository.CreateAsync(category);

				return Unit.Value;
			}
			catch (Exception e) {
				throw new MediatorException(e.Message);
			}
		}

		private Check Map(AddCheck request) =>
			new Check {
				Title = request.Title,
				Discription = request.Discription,
				StartDate = request.StartDate,
				EndDate = request.EndDate,
				CategoryId = request.CategoryId,
				UserId = request.UserId
			};
	}
}
