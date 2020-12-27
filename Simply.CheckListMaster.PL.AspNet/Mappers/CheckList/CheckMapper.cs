using Simply.CheckListMaster.BLL.Dto.CheckList;
using Simply.CheckListMaster.BLL.Dto.CheckList.Types;
using Simply.CheckListMaster.BLL.Enums;
using Simply.CheckListMaster.BLL.Mappers;
using Simply.CheckListMaster.PL.AspNet.Models.CheckLists;
using Simply.CheckListMaster.PL.AspNet.Models.CheckLists.Types;

namespace Simply.CheckListMaster.PL.AspNet.Mappers.CheckList {
	public class CheckMapper : IMapper<CheckDto, CheckModel> {
		public CheckDto BackMap(CheckModel value) =>
			new CheckDto {
				Id = value.Id,
				Title = value.Title,
				Discription = value.Discription,
				StartDate = value.StartDate,
				EndDate = value.EndDate,
				IsCompleted = value.IsCompleted,
				UserId = value.UserId,
				Category = value.Category != null && value.Category.Id.HasValue
					? new CategoryDto {
						Id = value.Category.Id.Value,
						Name = value.Category.Name
					}
					: null
			};

		public CheckModel Map(CheckDto value) =>
			new CheckModel {
				Id = value.Id,
				Title = value.Title,
				Discription = value.Discription,
				StartDate = value.StartDate,
				EndDate = value.EndDate,
				IsCompleted = value.IsCompleted,
				State = (StateType) value.StateId,
				UserId = value.UserId,
				Category = value.Category != null 
					? new CheckCategoryModel {
						Id = value.Category.Id,
						Name = value.Category.Name
					}
					: new CheckCategoryModel()
			};

	}
}
