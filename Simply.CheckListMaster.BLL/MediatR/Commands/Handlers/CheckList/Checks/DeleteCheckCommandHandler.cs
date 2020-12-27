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
	public class DeleteCheckCommandHandler : ICommandHandler<DeleteCheck> {
		private readonly IRepository<Check> _repository;

		public DeleteCheckCommandHandler(IRepository<Check> repository) {
			Contract.Requires(repository != null);

			_repository = repository;
		}

		public async Task<Unit> Handle(DeleteCheck request, CancellationToken cancellationToken) {
			try {
				await _repository.DeleteAsync(request.Id);

				return Unit.Value;
			}
			catch (Exception e) {
				throw new MediatorException(e.Message);
			}
		}
	}
}
