using Core.Commands;
using Core.Database;
using Core.ViewManager;
using Core.ViewManager.Data;
using Game.Data;
using Game.Model.Tables;

namespace Game.Commands
{
    public class StartCommand : ICommand
    {
        public void Execute()
        {
            ViewManager.Instance.Init();
            RegisterViews();

            CreateDatabase();
        }

        private void CreateDatabase()
        {
            
        }

        private void RegisterViews()
        {
            ViewManager.Instance.RegisterView(ViewNames.SplashScreen,   LayerNames.ScreenLayer);
            ViewManager.Instance.RegisterView(ViewNames.MainMenuScreen, LayerNames.ScreenLayer);
            ViewManager.Instance.RegisterView(ViewNames.GameHudView,    LayerNames.ScreenLayer);
            
            ViewManager.Instance.RegisterView(ViewNames.GameView,      LayerNames.ThreeDLayer);

            ViewManager.Instance.RegisterView(ViewNames.OptionsView,   LayerNames.WindowLayer);
            ViewManager.Instance.RegisterView(ViewNames.ShopView,      LayerNames.WindowLayer);
        }
    }
}
