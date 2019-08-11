using MediatR;

namespace SimpleBookKeeping.Common.CommandInterfaces
{
    public interface ICommand : IRequest<bool>
    {
    }
}
