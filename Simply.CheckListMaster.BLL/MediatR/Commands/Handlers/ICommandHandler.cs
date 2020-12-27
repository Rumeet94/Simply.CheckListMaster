using MediatR;

namespace Simply.CheckListMaster.BLL.MediatR.Commands.Handlers {
	public interface ICommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : IRequest<Unit> {
	}
}
