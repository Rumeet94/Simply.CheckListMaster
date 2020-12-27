using System.Diagnostics.Contracts;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.Mapper;

namespace Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.Creater {
	public class DbModelsCreater : IDbModelsCreater {
		private readonly IDbModelsCreaterMapper _mapper;

		public DbModelsCreater(IDbModelsCreaterMapper mapper) {
			Contract.Requires(mapper != null);

			_mapper = mapper;
		}

		public void CreateModels(ModelBuilder modelBuilder) {
			var models = _mapper.Map().ToList();

			models.ForEach(m => m.CreateModel(modelBuilder));
		}
	}
}
