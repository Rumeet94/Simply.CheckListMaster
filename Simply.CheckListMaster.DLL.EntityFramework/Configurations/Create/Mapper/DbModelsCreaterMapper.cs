using System.Collections.Generic;

using Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies;
using Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies.AspNetIdentity;
using Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies.AspNetIdentity.Roles;
using Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies.AspNetIdentity.Users;
using Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies.CheckList;

namespace Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.Mapper {
	public class DbModelsCreaterMapper : IDbModelsCreaterMapper {
		public IEnumerable<IDbModelCreaterStrategy> Map() {
			yield return new CategoryDbModelCreaterStrategy();
			yield return new CheckDbModelCreaterStrategy();
			yield return new AspNetAnnotationDbModelCreaterStrategy();
			yield return new AspNetRoleClaimsDbModelCreaterStrategy();
			yield return new AspNetRolesDbModelCreaterStrategy();
			yield return new AspNetUserClaimsDbModelCreaterStrategy();
			yield return new AspNetUserLoginsDbModelCreaterStrategy();
			yield return new AspNetUserRolesDbModelCreaterStrategy();
			yield return new AspNetUsersDbModelCreaterStrategy();
			yield return new AspNetUserTokensDbModelCreaterStrategy();
		}
	}
}
