using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Simply.CheckListMaster.DLL.EntityFramework.Repositories;

using System.Diagnostics.Contracts;
using Simply.CheckListMaster.BLL.MediatR.Queries.CheckList.Checks;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList;
using Simply.CheckListMaster.BLL.Dto.CheckList;
using Simply.CheckListMaster.BLL.Mappers;
using Simply.CheckListMaster.BLL.Exceptions;

namespace Simply.CheckListMaster.BLL.MediatR.Queries.Handlers.CheckList.Checks {
	public class GetCheckListByUserIdQueryHandler : IQueryHandler<GetCheckListByUserId, IEnumerable<CheckDto>> {
		private readonly IRepository<Check> _checkRepository;
		private readonly IMapper<Check, CheckDto> _mapper;

		public GetCheckListByUserIdQueryHandler(IRepository<Check> checkRepository, IMapper<Check, CheckDto> mapper) {
			Contract.Requires(checkRepository != null);
			Contract.Requires(mapper != null);

			_checkRepository = checkRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<CheckDto>> Handle(GetCheckListByUserId request, CancellationToken cancellationToken) {
			try {
			var checkList = await _checkRepository.GetAsync(c => c.UserId == request.UserId);

			return checkList
				.Where(c => 
					(
						!request.CategoryId.HasValue
						|| request.CategoryId.Value == c.CategoryId
					)
					&& (
						!request.StateId.HasValue
						|| request.StateId.Value == c.StateId
					)
				)
				.Select(c => _mapper.Map(c));
			}
			catch (Exception e) {
				throw new MediatorException(e.Message);
			}
		}
	}
}
