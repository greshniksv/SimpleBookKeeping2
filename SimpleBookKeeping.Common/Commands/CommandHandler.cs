using System.Threading;
using System.Threading.Tasks;
using SimpleBookKeeping.Common.CommandService;

namespace SimpleBookKeeping.Common.Commands
{
    public class CommandHandler : ICommandHandler<Command>
    {
        public Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => true, cancellationToken);
        }
    }
}
