using System;
using System.ComponentModel.DataAnnotations;

using Simply.CheckListMaster.BLL.Enums;
using Simply.CheckListMaster.PL.AspNet.Models.CheckLists.Types;

namespace Simply.CheckListMaster.PL.AspNet.Models.CheckLists {
	public class CheckModel {
		[Required]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		public string Discription { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public bool IsCompleted { get; set; }

		public StateType State { get; set; }
		
		public CheckCategoryModel Category { get; set; }

		public string UserId { get; set; }
	}
}
