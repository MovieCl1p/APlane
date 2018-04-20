using Core.Binder;
using Core.Dispatcher;
using System;
using Game.Factory;
using Game.Model;
using Game.Player.Control;
using Game.Services;
using Game.Services.Interfaces;

namespace Game.Config
{
    public class AppConfig
    {
        public void AddBindings()
        {
            BindModels();
            BindServices();
            BindInjections();
        }

        private void BindInjections()
        {
            BindManager.Bind<IDispatcher>().To<Dispatcher>().ToSingleton();
            
            BindManager.Bind<IPlayerControl>().To<PlayerControl>().ToSingleton();
            
            BindManager.Bind<GameFactory>().ToSingleton();
        }

        private void BindModels()
        {
            BindManager.Bind<LevelSessionModel>().ToSingleton();
        }

        private void BindServices()
        {
            BindManager.Bind<IShopService>().To<ShopService>().ToSingleton();
            
            BindManager.Bind<IUserProfileService>().To<UserProfileService>().ToSingleton();
            BindManager.Bind<IShipSpriteLoaderService>().To<ShipSpriteSpriteLoaderService>().ToSingleton();
        }
    }
}
