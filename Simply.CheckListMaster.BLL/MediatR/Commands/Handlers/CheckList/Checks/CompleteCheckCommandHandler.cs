using System;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Simply.CheckListMaster.BLL.Enums;
using Simply.CheckListMaster.BLL.Exceptions;
using Simply.CheckListMaster.BLL.MediatR.Commands.CheckList.Checks;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList;
using Simply.CheckListMaster.DLL.EntityFramework.Repositories;

namespace Simply.CheckListMaster.BLL.MediatR.Commands.Handlers.CheckList.Checks {
	public class CompleteCheckCommandHandler : ICommandHandler<CompleteCheck> {
		private readonly IRepository<Check> _repository;

		public CompleteCheckCommandHandler(IRepository<Check> repository) {
			Contract.Requires(repository != null);

			_repository = repository;
		}

		public async Task<Unit> Handle(CompleteCheck request, CancellationToken cancellationToken) {
			try {
				var check = await _repository.GetSingleAsync(request.Id);

				check.StateId = (int) StateType.Completed;
				check.IsCompleted = true;

				await _repository.UpdateAsync(check);

				return Unit.Value;
			}
			catch (Exception e) {
				throw new MediatorException(e.Message);
			}
		}
	}
}
