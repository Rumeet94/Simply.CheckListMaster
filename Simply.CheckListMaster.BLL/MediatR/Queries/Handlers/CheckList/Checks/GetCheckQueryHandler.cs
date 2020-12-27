using System;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

using Simply.CheckListMaster.BLL.Dto.CheckList;
using Simply.CheckListMaster.BLL.Exceptions;
using Simply.CheckListMaster.BLL.Mappers;
using Simply.CheckListMaster.BLL.MediatR.Queries.CheckList.Checks;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList;
using Simply.CheckListMaster.DLL.EntityFramework.Repositories;

namespace Simply.CheckListMaster.BLL.MediatR.Queries.Handlers.CheckList.Checks {
	public class GetCheckQueryHandler : IQueryHandler<GetCheck, CheckDto> {
		private readonly IRepository<Check> _checkRepository;
		private readonly IMapper<Check, CheckDto> _mapper;

		public GetCheckQueryHandler(IRepository<Check> checkRepository, IMapper<Check, CheckDto> mapper) {
			Contract.Requires(checkRepository != null);
			Contract.Requires(mapper != null);

			_checkRepository = checkRepository;
			_mapper = mapper;
		}

		public async Task<CheckDto> Handle(GetCheck request, CancellationToken cancellationToken) {
			try {
				var check = await _checkRepository.GetSingleAsync(request.Id);

				return _mapper.Map(check);
			}
			catch (Exception e) {
				throw new MediatorException(e.Message);
			}
		}
	}
}
