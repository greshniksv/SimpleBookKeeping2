using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Common.Notification
{
    public class NotifyHandler: INotificationHandler<Notify>
    {
        public Task Handle(Notify notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Notify");
            return Task.CompletedTask;
        }
    }
}
