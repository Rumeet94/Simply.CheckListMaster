using Microsoft.EntityFrameworkCore;

using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList;

namespace Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies.CheckList {
	internal class CheckDbModelCreaterStrategy : IDbModelCreaterStrategy {
		public void CreateModel(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Check>()
				.Property(ch => ch.Id)
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<Check>()
				.Property(ch => ch.Title)
				.IsRequired();

			modelBuilder.Entity<Check>()
				.Property(ch => ch.Title)
				.IsRequired()
				.HasDefaultValueSql("0");

			modelBuilder.Entity<Check>()
				.Property(ch => ch.IsCompleted)
				.IsRequired()
				.HasDefaultValueSql("0");

			modelBuilder.Entity<Check>()
				.HasOne(ch => ch.Category)
				.WithMany(c => c.Checks)
				.HasForeignKey(ch => ch.CategoryId)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Check>()
				.HasOne(ch => ch.User)
				.WithMany()
				.HasForeignKey(ch => ch.UserId)
				.IsRequired();
		}
	}
}
