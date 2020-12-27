using System;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

using Simply.CheckListMaster.BLL.Dto.CheckList.Types;
using Simply.CheckListMaster.BLL.Exceptions;
using Simply.CheckListMaster.BLL.MediatR.Queries.CheckList.Categories;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList.Types;
using Simply.CheckListMaster.DLL.EntityFramework.Repositories;

namespace Simply.CheckListMaster.BLL.MediatR.Queries.Handlers.CheckList.Categories {
	public class GetCategoryQueryHandler : IQueryHandler<GetCategory, CategoryDto> {
		private readonly IRepository<Category> _repository;

		public GetCategoryQueryHandler(IRepository<Category> repository) {
			Contract.Requires(repository != null);

			_repository = repository;
		}

		public async Task<CategoryDto> Handle(GetCategory request, CancellationToken cancellationToken) {
			try {
				var category = await _repository.GetSingleAsync(request.Id);

				return new CategoryDto {
					Id = category.Id,
					Name = category.Name
				};
			}
			catch (Exception e) {
				throw new MediatorException(e.Message);
			}
		}
	}
}
