using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using Simply.CheckListMaster.DLL.EntityFramework.Context;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList.Types;

namespace Simply.CheckListMaster.DLL.EntityFramework.Repositories.CheckList.Types {
	public class CategoryRepository : IRepository<Category> {
		private readonly CheckListMasterDbContext _context;

		public CategoryRepository(CheckListMasterDbContext context) {
			Contract.Requires(context != null);

			_context = context;
		}

		public void Create(Category item) {
			_context.Categories.Add(item);
			_context.SaveChanges();
		}

		public void Delete(int id) {
			var category = _context.Categories.Find(id);

			_context.Categories.Remove(category);
			_context.SaveChanges();
		}

		public IEnumerable<Category> Get() =>
			_context.Categories?
				.Include(c => c.User)
				.Include(c => c.Checks);

		public IEnumerable<Category> Get(Expression<Func<Category, bool>> predicate) =>
			_context.Categories?.Where(predicate)
				.Include(c => c.User)
				.Include(c => c.Checks);

		public Category GetSingle(int id) =>
			_context.Categories.Find(id);

		public void MassUpdate(IEnumerable<Category> items) {
			throw new NotImplementedException();
		}

		public void Update(Category item) {
			_context.Update(item);
			_context.SaveChanges();
		}
	}
}
