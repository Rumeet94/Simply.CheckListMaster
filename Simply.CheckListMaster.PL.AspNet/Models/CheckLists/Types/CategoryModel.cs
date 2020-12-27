using System.ComponentModel.DataAnnotations;

namespace Simply.CheckListMaster.PL.AspNet.Models.CheckLists.Types {
	public class CategoryModel {
		[Required]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}
