using Microsoft.EntityFrameworkCore;

namespace Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.Creater {
	public interface IDbModelsCreater {
		void CreateModels(ModelBuilder modelBuilder);
	}
}
