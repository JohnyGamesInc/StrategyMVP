namespace _Strategy._Main.Abstractions.Commands
{
    
    public interface ICommandExecutor
    {
        
        void ExecuteCommand(object command);
        
    }
}