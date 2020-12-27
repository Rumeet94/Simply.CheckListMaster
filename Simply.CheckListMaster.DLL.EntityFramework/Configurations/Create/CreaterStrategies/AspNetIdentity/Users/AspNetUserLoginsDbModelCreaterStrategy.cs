using Microsoft.EntityFrameworkCore;

namespace Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies.AspNetIdentity.Users {
	internal class AspNetUserLoginsDbModelCreaterStrategy : IDbModelCreaterStrategy {
		public void CreateModel(ModelBuilder modelBuilder) {
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b => {
				b.Property<string>("LoginProvider")
					.HasColumnType("nvarchar(128)")
					.HasMaxLength(128);

				b.Property<string>("ProviderKey")
					.HasColumnType("nvarchar(128)")
					.HasMaxLength(128);

				b.Property<string>("ProviderDisplayName")
					.HasColumnType("nvarchar(max)");

				b.Property<string>("UserId")
					.IsRequired()
					.HasColumnType("nvarchar(450)");

				b.HasKey("LoginProvider", "ProviderKey");

				b.HasIndex("UserId");

				b.ToTable("AspNetUserLogins");
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b => {
				b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
					.WithMany()
					.HasForeignKey("UserId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});
		}
	}
}
