using Core.Binder;
using Core.Commands;
using Game.Model;

namespace Game.Commands.Level
{
    public class RestartLevelCommand : ICommand
    {
        public void Execute()
        {
            LevelSessionModel sessionModel = BindManager.GetInstance<LevelSessionModel>();
            sessionModel.LevelTime = 0;
            sessionModel.Score = 0;
        }
    }
}