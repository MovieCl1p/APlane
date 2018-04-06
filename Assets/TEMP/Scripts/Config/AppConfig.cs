using System;
using Core.Binder;
using Game.Model;
using Game.Player.Control;
using Game.Factory;
using Core.Dispatcher;
using Game.Player;
using Game.Services.Interfaces;
using Game.Services;

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
            BindManager.Bind<IShipService>().To<ShipService>().ToSingleton();
        }
    }
}
