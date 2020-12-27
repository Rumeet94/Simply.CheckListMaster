using System;

using Simply.CheckListMaster.BLL.Dto.CheckList.Types;

namespace Simply.CheckListMaster.BLL.Dto.CheckList {
	public class CheckDto {
		public int Id { get; set; }

		public string Title { get; set; }

		public string Discription { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public bool IsCompleted { get; set; }

		public int StateId { get; set; }

		public CategoryDto Category { get; set; }

		public string UserId { get; set; }
	}
}
