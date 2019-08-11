using MediatR;

namespace SimpleBookKeeping.Common.CommandService
{
    public interface ICommandHandler<in T> : IRequestHandler<T, bool> where T : IRequest<bool>
    {
    }
}
