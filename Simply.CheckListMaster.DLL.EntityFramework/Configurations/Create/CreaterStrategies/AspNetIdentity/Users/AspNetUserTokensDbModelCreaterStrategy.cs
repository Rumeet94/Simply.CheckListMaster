using Microsoft.EntityFrameworkCore;

namespace Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies.AspNetIdentity.Users {
	internal class AspNetUserTokensDbModelCreaterStrategy : IDbModelCreaterStrategy {
		public void CreateModel(ModelBuilder modelBuilder) {
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b => {
				b.Property<string>("UserId")
					.HasColumnType("nvarchar(450)");

				b.Property<string>("LoginProvider")
					.HasColumnType("nvarchar(128)")
					.HasMaxLength(128);

				b.Property<string>("Name")
					.HasColumnType("nvarchar(128)")
					.HasMaxLength(128);

				b.Property<string>("Value")
					.HasColumnType("nvarchar(max)");

				b.HasKey("UserId", "LoginProvider", "Name");

				b.ToTable("AspNetUserTokens");
			});

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b => {
				b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
					.WithMany()
					.HasForeignKey("UserId")
					.OnDelete(DeleteBehavior.Cascade)
					.IsRequired();
			});
		}
	}
}
