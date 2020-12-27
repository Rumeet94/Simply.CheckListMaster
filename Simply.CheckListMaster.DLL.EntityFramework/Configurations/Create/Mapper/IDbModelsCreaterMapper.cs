using System.Collections.Generic;

using Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies;

namespace Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.Mapper {
	public interface IDbModelsCreaterMapper {
		IEnumerable<IDbModelCreaterStrategy> Map();
	}
}
