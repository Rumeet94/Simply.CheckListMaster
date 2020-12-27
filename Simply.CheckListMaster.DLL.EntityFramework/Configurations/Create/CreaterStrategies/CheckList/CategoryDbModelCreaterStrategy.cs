using Microsoft.EntityFrameworkCore;

using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList.Types;

namespace Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies.CheckList {
	internal class CategoryDbModelCreaterStrategy : IDbModelCreaterStrategy {
		public void CreateModel(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Category>()
				.Property(c => c.Id)
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<Category>()
				.Property(c => c.UserId)
				.IsRequired();

			modelBuilder.Entity<Category>()
				.Property(c => c.Name)
				.IsRequired();

			modelBuilder.Entity<Category>()
				.HasOne(c => c.User)
				.WithMany()
				.HasForeignKey(c => c.UserId)
				.IsRequired();
		}
	}
}
