using System;

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simply.CheckListMaster.DLL.EntityFramework.Repositories {
	public interface IRepository<T> {
		IEnumerable<T> Get();

		IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

		T GetSingle(int id);

		void Create(T item);

		void Update(T item);

		void Delete(int id);

		void MassUpdate(IEnumerable<T> items);

		Task<IEnumerable<T>> GetAsync() =>
			Task.Run(() => Get());

		Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate) =>
			Task.Run(() => Get(predicate));

		Task<T> GetSingleAsync(int id) =>
			Task.Run(() => GetSingle(id));

		Task CreateAsync(T item) =>
			Task.Run(() => Create(item));

		Task UpdateAsync(T item) =>
			Task.Run(() => Update(item));

		Task DeleteAsync(int id) =>
			Task.Run(() => Delete(id));

		Task MassUpdateAsync(IEnumerable<T> items) =>
			Task.Run(() => MassUpdate(items));
	}
}
