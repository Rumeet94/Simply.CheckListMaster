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
	public class UpdateCheckCommandHandler : ICommandHandler<UpdateCheck> {
		private readonly IRepository<Check> _repository;

		public UpdateCheckCommandHandler(IRepository<Check> repository) {
			Contract.Requires(repository != null);

			_repository = repository;
		}

		public async Task<Unit> Handle(UpdateCheck request, CancellationToken cancellationToken) {
			try {
				var check = _repository.GetSingle(request.Id);

				Map(check, request);

				await _repository.UpdateAsync(check);

				return Unit.Value;
			}
			catch (Exception e) {
				throw new MediatorException(e.Message);
			}
		}

		private void Map(Check check, UpdateCheck request) {
			check.Title = request.Title;
			check.Discription = request.Discription;
			check.StartDate = request.StartDate;
			check.EndDate = request.EndDate;
			check.CategoryId = request.CategoryId;
		}
	}
}
