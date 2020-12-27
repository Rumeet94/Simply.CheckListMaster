using MediatR;

namespace Simply.CheckListMaster.BLL.MediatR.Queries {
	public interface IQuery<out T> : IRequest<T> {
	}
}
