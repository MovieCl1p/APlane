using Core.Binder;
using Core.Commands;
using Core.Dispatcher;
using Core.UnityUtils;
using Game.Data;
using Game.Factory;
using Game.Model;
using Game.Player;
using Game.Rocket;
using UnityEngine;

namespace Game.Commands.Level
{
    public class CreateRocketCommand : ICommand, IUpdateHandler
    {
        private readonly Transform _player;
        private IDispatcher _dispatcher;

        private int _currentDestroyed;
        private int _currentCreated;
        private LevelSessionModel _levelSessionModel;

        public CreateRocketCommand(Transform player)
        {
            _player = player;
        }

        public void Execute()
        {
            _currentCreated = 5;
            _dispatcher = BindManager.GetInstance<IDispatcher>();
            _levelSessionModel = BindManager.GetInstance<LevelSessionModel>();
            
            _dispatcher.AddListener(LevelEvent.Start, OnLevelStart);
            
            UpdateNotifier.Instance.Register(this);
        }

        private void OnLevelStart()
        {
            _dispatcher.RemoveListener(LevelEvent.Start, OnLevelStart);
            CreateRockets();
            
            _dispatcher.AddListener(LevelEvent.OnRocketDestroyed, OnRocketDestroyed);
        }

        private void OnRocketDestroyed()
        {
            _currentDestroyed++;
            if (_currentDestroyed % _currentCreated >= _currentCreated - 1)
            {
                _counter = 0;
                CreateRockets();
            }
        }

        private void CreateRockets()
        {
            GameFactory factory = BindManager.GetInstance<GameFactory>();
            
            for (int i = 0; i < _currentCreated; i++)
            {
                RocketController rocket = factory.CreateRocket();
                Vector3 dir = (Random.insideUnitSphere * 100);
                dir.z = 0;
                rocket.CachedTransform.position = _player.position + dir;
                rocket.SetTarget(_player);
                rocket.SetVelocity(_levelSessionModel.LevelTime % 20);
            }
        }

        public void FinishCommand()
        {
            UpdateNotifier.Instance.UnRegister(this);
            _dispatcher.RemoveListener(LevelEvent.OnRocketDestroyed, OnRocketDestroyed);
        }

        public bool IsUpdating { get; set; }
        public bool IsRegistered { get; set; }

        private float _counter;
        
        public void OnUpdate()
        {
            _counter += Time.deltaTime;
            if (_counter >= 10)
            {
                _counter = 0;
                CreateRockets();
            }
        }
    }
}