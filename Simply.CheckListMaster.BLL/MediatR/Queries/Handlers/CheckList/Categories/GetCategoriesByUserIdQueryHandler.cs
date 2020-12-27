using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Simply.CheckListMaster.BLL.Dto.CheckList.Types;
using Simply.CheckListMaster.DLL.EntityFramework.Repositories;

using Simply.CheckListMaster.BLL.MediatR.Queries.CheckList.Categories;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList.Types;
using System.Diagnostics.Contracts;
using System;
using Simply.CheckListMaster.BLL.Exceptions;

namespace Simply.CheckListMaster.BLL.MediatR.Queries.Handlers.CheckList.Categories {
	public class GetCategoriesByUserIdQueryHandler : IQueryHandler<GetCategoriesByUserId, IEnumerable<CategoryDto>> {
		private readonly IRepository<Category> _repository;

		public GetCategoriesByUserIdQueryHandler(IRepository<Category> repository) {
			Contract.Requires(repository != null);

			_repository = repository;
		}

		public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesByUserId request, CancellationToken cancellationToken) {
			try {
				var userCategories = await _repository.GetAsync(c => c.UserId == request.UserId);

				return userCategories.Select(c =>
					new CategoryDto {
						Id = c.Id,
						Name = c.Name
					}
				);
			}
			catch (Exception e) {
				throw new MediatorException(e.Message);
			}
		}
	}
}
