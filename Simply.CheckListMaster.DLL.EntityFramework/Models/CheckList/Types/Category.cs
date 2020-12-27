using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;

namespace Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList.Types {
	public class Category : BaseModelType {
		public Category() {
		}

		public Category(List<Check> checks)
			: base(checks) {
		}

		public string UserId { get; set; }

		public IdentityUser User { get; set; }
	}
}
