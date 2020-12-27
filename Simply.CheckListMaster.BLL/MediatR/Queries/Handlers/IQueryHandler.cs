using MediatR;

namespace Simply.CheckListMaster.BLL.MediatR.Queries.Handlers {
	internal interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IRequest<TResponse> {
	}
}
