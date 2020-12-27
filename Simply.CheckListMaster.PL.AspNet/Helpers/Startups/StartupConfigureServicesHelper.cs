using System.Reflection;

using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Simply.CheckListMaster.BLL.Dto.CheckList;
using Simply.CheckListMaster.BLL.Mappers;
using Simply.CheckListMaster.BLL.Mappers.CheckList;
using Simply.CheckListMaster.BLL.MediatR.Commands.Handlers.CheckList.Categories;
using Simply.CheckListMaster.BLL.MediatR.Commands.Handlers.CheckList.Checks;
using Simply.CheckListMaster.BLL.MediatR.Queries.Handlers.CheckList.Categories;
using Simply.CheckListMaster.BLL.MediatR.Queries.Handlers.CheckList.Checks;
using Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.Creater;
using Simply.CheckListMaster.DLL.EntityFramework.Configurations.Create.Mapper;
using Simply.CheckListMaster.DLL.EntityFramework.Context;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList.Types;
using Simply.CheckListMaster.DLL.EntityFramework.Repositories;
using Simply.CheckListMaster.DLL.EntityFramework.Repositories.CheckList;
using Simply.CheckListMaster.DLL.EntityFramework.Repositories.CheckList.Types;
using Simply.CheckListMaster.PL.AspNet.Mappers.CheckList;
using Simply.CheckListMaster.PL.AspNet.Models.CheckLists;

namespace Simply.CheckListMaster.PL.AspNet.Helpers.Startups {
	public static class StartupConfigureServicesHelper {
		public static void AddDLLConfigure(IServiceCollection services, IConfiguration configuration) {
			services.AddDbContext<CheckListMasterDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection"),
					b => b.MigrationsAssembly("Simply.CheckListMaster.DLL.EntityFramework")
				)
			);

			services.AddScoped<CheckListMasterDbContext>();
			services.AddSingleton<IDbModelsCreaterMapper, DbModelsCreaterMapper>();
			services.AddSingleton<IDbModelsCreater, DbModelsCreater>();
			services.AddScoped<IRepository<Category>, CategoryRepository>();
			services.AddScoped<IRepository<Check>, CheckRepository>();
		}

		public static void AddBLLConfigure(IServiceCollection services) {
			services.AddMediatR(typeof(GetCategoriesByUserIdQueryHandler).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(GetCategoryQueryHandler).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(AddCategoryCommandHandler).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(DeleteCategoryCommandHandler).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(UpdateCategoryCommandHandler).GetTypeInfo().Assembly);

			services.AddMediatR(typeof(GetCheckListByUserIdQueryHandler).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(AddCheckCommandHandler).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(DeleteCheckCommandHandler).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(UpdateCheckCommandHandler).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(CompleteCheckCommandHandler).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(RunCheckCommandHandler).GetTypeInfo().Assembly);
		}

		public static void AddPLConfigure(IServiceCollection services) {
			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
				.AddEntityFrameworkStores<CheckListMasterDbContext>();

			services.AddMediatR(typeof(Startup));

			services.AddControllersWithViews();
			services.AddRazorPages();

			services.AddSingleton<IMapper<CheckDto, CheckModel>, CheckMapper>();
			services.AddSingleton<IMapper<Check, CheckDto>, CheckDtoMapper>();
		}
	}
}
