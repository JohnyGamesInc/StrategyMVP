namespace _Strategy._Main.Abstractions.Commands
{
    
    public interface ICommandsQueue
    {
        
        void EnqueueCommand(object command);

        void Clear();

    }
}