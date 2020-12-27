using System.Diagnostics.Contracts;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.Creater;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList.Types;

namespace Simply.CheckListMaster.DLL.EntityFramework.Context {
	public class CheckListMasterDbContext : IdentityDbContext {
		private readonly IDbModelsCreater _dbModelsCreater;

		public CheckListMasterDbContext(
			DbContextOptions<CheckListMasterDbContext> options,
			IDbModelsCreater dbModelsCreater
		) : base(options) {
			Contract.Requires(dbModelsCreater != null);

			_dbModelsCreater = dbModelsCreater;
		}

		public DbSet<Category> Categories { get; set; }

		public DbSet<Check> Checks { get; set; }

		protected override void OnModelCreating(ModelBuilder builder) {
			_dbModelsCreater.CreateModels(builder);
		}
	}
}
