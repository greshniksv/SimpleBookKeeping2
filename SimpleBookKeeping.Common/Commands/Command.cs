using SimpleBookKeeping.Common.CommandInterfaces;

namespace SimpleBookKeeping.Common.Commands
{
    public class Command : ICommand
    {
        public string Data { get; set; }
    }
}
