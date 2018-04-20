using Core.Binder;
using Core.Commands;
using Core.Database;
using Core.ViewManager;
using Core.ViewManager.Data;
using Game.Data;
using Game.Model.Tables;
using Game.Services.Interfaces;
using UnityEngine;

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
            IUserProfileService service = BindManager.GetInstance<IUserProfileService>();
            service.CreateProfileModel();
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
