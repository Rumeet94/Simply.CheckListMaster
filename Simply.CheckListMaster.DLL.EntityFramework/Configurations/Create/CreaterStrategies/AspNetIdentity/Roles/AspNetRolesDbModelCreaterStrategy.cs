using Microsoft.EntityFrameworkCore;

namespace Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies.AspNetIdentity.Roles {
	internal class AspNetRolesDbModelCreaterStrategy : IDbModelCreaterStrategy {
		public void CreateModel(ModelBuilder modelBuilder) =>
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b => {
				b.Property<string>("Id")
					.HasColumnType("nvarchar(450)");

				b.Property<string>("ConcurrencyStamp")
					.IsConcurrencyToken()
					.HasColumnType("nvarchar(max)");

				b.Property<string>("Name")
					.HasColumnType("nvarchar(256)")
					.HasMaxLength(256);

				b.Property<string>("NormalizedName")
					.HasColumnType("nvarchar(256)")
					.HasMaxLength(256);

				b.HasKey("Id");

				b.HasIndex("NormalizedName")
					.IsUnique()
					.HasName("RoleNameIndex")
					.HasFilter("[NormalizedName] IS NOT NULL");

				b.ToTable("AspNetRoles");
			});
	}
}
