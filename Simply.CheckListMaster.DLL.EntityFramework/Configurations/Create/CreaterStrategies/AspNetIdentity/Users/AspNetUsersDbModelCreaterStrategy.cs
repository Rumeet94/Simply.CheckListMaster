using System;

using Microsoft.EntityFrameworkCore;

namespace Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.CreaterStrategies.AspNetIdentity.Users {
	internal class AspNetUsersDbModelCreaterStrategy : IDbModelCreaterStrategy {
		public void CreateModel(ModelBuilder modelBuilder) =>
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b => {
				b.Property<string>("Id")
					.HasColumnType("nvarchar(450)");

				b.Property<int>("AccessFailedCount")
					.HasColumnType("int");

				b.Property<string>("ConcurrencyStamp")
					.IsConcurrencyToken()
					.HasColumnType("nvarchar(max)");

				b.Property<string>("Email")
					.HasColumnType("nvarchar(256)")
					.HasMaxLength(256);

				b.Property<bool>("EmailConfirmed")
					.HasColumnType("bit");

				b.Property<bool>("LockoutEnabled")
					.HasColumnType("bit");

				b.Property<DateTimeOffset?>("LockoutEnd")
					.HasColumnType("datetimeoffset");

				b.Property<string>("NormalizedEmail")
					.HasColumnType("nvarchar(256)")
					.HasMaxLength(256);

				b.Property<string>("NormalizedUserName")
					.HasColumnType("nvarchar(256)")
					.HasMaxLength(256);

				b.Property<string>("PasswordHash")
					.HasColumnType("nvarchar(max)");

				b.Property<string>("PhoneNumber")
					.HasColumnType("nvarchar(max)");

				b.Property<bool>("PhoneNumberConfirmed")
					.HasColumnType("bit");

				b.Property<string>("SecurityStamp")
					.HasColumnType("nvarchar(max)");

				b.Property<bool>("TwoFactorEnabled")
					.HasColumnType("bit");

				b.Property<string>("UserName")
					.HasColumnType("nvarchar(256)")
					.HasMaxLength(256);

				b.HasKey("Id");

				b.HasIndex("NormalizedEmail")
					.HasName("EmailIndex");

				b.HasIndex("NormalizedUserName")
					.IsUnique()
					.HasName("UserNameIndex")
					.HasFilter("[NormalizedUserName] IS NOT NULL");

				b.ToTable("AspNetUsers");
			});
	}
}
