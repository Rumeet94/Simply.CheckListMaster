using System;

using Simply.CheckListMaster.BLL.Dto.CheckList;
using Simply.CheckListMaster.BLL.Dto.CheckList.Types;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList;

namespace Simply.CheckListMaster.BLL.Mappers.CheckList {
	public class CheckDtoMapper : IMapper<Check, CheckDto> {
		public Check BackMap(CheckDto value) {
			throw new NotImplementedException();
		}

		public CheckDto Map(Check value) =>
			new CheckDto {
				Id = value.Id,
				Title = value.Title,
				Discription = value.Discription,
				StartDate = value.StartDate,
				EndDate = value.EndDate,
				IsCompleted = value.IsCompleted,
				StateId = value.StateId,
				Category = value.Category != null
					? new CategoryDto {
						Id = value.Category.Id,
						Name = value.Category.Name
					}
					: null,
				UserId = value.UserId
			};
	}
}
