using Microsoft.EntityFrameworkCore;

namespace Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies {
	public interface IDbModelCreaterStrategy {
		void CreateModel(ModelBuilder modelBuilder);
	}
}
