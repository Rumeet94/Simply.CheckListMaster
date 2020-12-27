using System;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList.Types;

namespace Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList {
	public class Check {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Title { get; set; }

		public string Discription { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public bool IsCompleted { get; set; }

		public int? CategoryId { get; set; }

		public int StateId { get; set; }

		public Category Category { get; set; }

		public string UserId { get; set; }

		public IdentityUser User { get; set; }
	}
}
