using Microsoft.EntityFrameworkCore;

namespace Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies.AspNetIdentity.Users {
	internal class AspNetUserRolesDbModelCreaterStrategy : IDbModelCreaterStrategy {
		public void CreateModel(ModelBuilder modelBuilder) {
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b => {
				b.Property<string>("UserId")
					.HasColumnType("nvarchar(450)");

				b.Property<string>("RoleId")
					.HasColumnType("nvarchar(450)");

				b.HasKey("UserId", "RoleId");

				b.HasIndex("RoleId");

				b.ToTable("AspNetUserRoles");
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b => {
				b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
					.WithMany()
					.HasForeignKey("RoleId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();

				b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
					.WithMany()
					.HasForeignKey("UserId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});
		}
	}
}
