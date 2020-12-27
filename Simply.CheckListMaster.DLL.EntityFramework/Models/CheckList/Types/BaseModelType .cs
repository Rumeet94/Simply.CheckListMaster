using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList.Types {
	public abstract class BaseModelType {
		public BaseModelType() {
		}

		public BaseModelType(List<Check> checks) {
			Contract.Requires(checks != null);

			Checks = checks;
		}

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }

		public List<Check> Checks { get; set; }
	}
}
