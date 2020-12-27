using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using Simply.CheckListMaster.DLL.EntityFramework.Context;
using Simply.CheckListMaster.DLL.EntityFramework.Models.CheckList;

namespace Simply.CheckListMaster.DLL.EntityFramework.Repositories.CheckList {
	public class CheckRepository : IRepository<Check> {
		private readonly CheckListMasterDbContext _context;

		public CheckRepository(CheckListMasterDbContext context) {
			Contract.Requires(context != null);

			_context = context;
		}

		public void Create(Check item) {
			_context.Checks.Add(item);
			_context.SaveChanges();
		}

		public void Delete(int id) {
			var user = _context.Checks.Find(id);

			_context.Checks.Remove(user);
			_context.SaveChanges();
		}

		public IEnumerable<Check> Get() =>
			_context.Checks
				.Include(c => c.Category)
				.Include(c => c.User);

		public IEnumerable<Check> Get(Expression<Func<Check, bool>> predicate) =>
			_context.Checks.Where(predicate)
				.Include(c => c.Category)
				.Include(c => c.User);

		public Check GetSingle(int id) =>
			_context.Checks
				.Include(c => c.Category)
				.Include(c => c.User)
				.FirstOrDefault(c => c.Id == id);

		public void Update(Check item) {
			_context.Update(item);
			_context.SaveChanges();
		}

		public void MassUpdate(IEnumerable<Check> items) {
			items
				.ToList()
				.ForEach(c => _context.Update(c));

			_context.SaveChanges();
		}
	}
}
