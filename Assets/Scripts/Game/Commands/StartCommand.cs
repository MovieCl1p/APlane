using Core.Commands;
using Core.ViewManager;
using Core.ViewManager.Data;
using Game.Data;

namespace Game.Commands
{
    public class StartCommand : ICommand
    {
        public void Execute()
        {
            ViewManager.Instance.Init();
            RegisterViews();
        }

        private void RegisterViews()
        {
            ViewManager.Instance.RegisterView(ViewNames.SplashScreen,   LayerNames.ScreenLayer);
            ViewManager.Instance.RegisterView(ViewNames.MainMenuScreen, LayerNames.ScreenLayer);
            ViewManager.Instance.RegisterView(ViewNames.GameScreen,     LayerNames.ScreenLayer);

            ViewManager.Instance.RegisterView(ViewNames.FinishView,     LayerNames.WindowLayer);
            ViewManager.Instance.RegisterView(ViewNames.PauseView,      LayerNames.WindowLayer);
        }
    }
}
