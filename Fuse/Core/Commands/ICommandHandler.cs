namespace Fuse.Core.Commands
{
    public interface ICommandHandler
    {
        void HandleCommand(string text);
    }
}