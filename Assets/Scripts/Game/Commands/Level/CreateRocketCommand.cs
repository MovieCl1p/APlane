using Core.Binder;
using Core.Commands;
using Core.Dispatcher;
using Core.UnityUtils;
using Game.Data;
using Game.Factory;
using Game.Player;
using Game.Rocket;
using UnityEngine;

namespace Game.Commands.Level
{
    public class CreateRocketCommand : ICommand
    {
        private readonly Transform _player;
        private IDispatcher _dispatcher;

        public CreateRocketCommand(Transform player)
        {
            _player = player;
        }

        public bool IsUpdating { get; set; }
        
        public bool IsRegistered { get; set; }

        public void Execute()
        {
            _dispatcher = BindManager.GetInstance<IDispatcher>();
            _dispatcher.AddListener(LevelEvent.Start, OnLevelStart);
        }

        private void OnLevelStart()
        {
            CreateRockets();
        }

        private void CreateRockets()
        {
            GameFactory factory = BindManager.GetInstance<GameFactory>();
            for (int i = 0; i < 5; i++)
            {
                RocketController rocket = factory.CreateRocket();
                Vector3 dir = (Random.insideUnitSphere * 50);
                dir.z = 0;
                rocket.CachedTransform.position = _player.position + dir;
                rocket.SetTarget(_player);
            }
        }
    }
}