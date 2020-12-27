using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Simply.CheckListMaster.BLL.Enums;
using Simply.CheckListMaster.BLL.Exceptions;
using Simply.CheckListMaster.BLL.MediatR.Commands.CheckList.Checks;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList;
using Simply.CheckListMaster.DLL.EntityFramework.Repositories;

namespace Simply.CheckListMaster.BLL.MediatR.Commands.Handlers.CheckList.Checks {
	public class RunCheckCommandHandler : ICommandHandler<RunCheck> {
		private readonly IRepository<Check> _repository;

		public RunCheckCommandHandler(IRepository<Check> repository) {
			Contract.Requires(repository != null);

			_repository = repository;
		}

		public async Task<Unit> Handle(RunCheck request, CancellationToken cancellationToken) {
			try {
				var checkList = await _repository
					.GetAsync(c =>
						c.UserId == request.UserId
						&& (
							c.StateId == (int) StateType.Processing
							|| c.Id == request.Id
						)
					);

				if (checkList.Any()) { 
					await UpdateStates(checkList, request.Id);
				}

				return Unit.Value;
			}
			catch (Exception e) {
				throw new MediatorException(e.Message);
			}
		}

		private async Task UpdateStates(IEnumerable<Check> checkList, int id) {
			foreach (var check in checkList) {
				check.StateId = check.Id == id
					? (int) StateType.Processing
					: (int) StateType.Paused;
			}

			await _repository.MassUpdateAsync(checkList);
		}
	}
}
