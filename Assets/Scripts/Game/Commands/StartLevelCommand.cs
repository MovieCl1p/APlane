using Core.Commands;
using Core.ViewManager;
using Game.Data;

namespace Game.Commands
{
    public class StartLevelCommand : ICommand
    {
        public void Execute()
        {
            ViewManager.Instance.SetView(ViewNames.GameView);
            
            
            
        }
    }
}