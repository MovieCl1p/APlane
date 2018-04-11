using Core.Binder;
using Core.Commands;
using Game.Asteroid;
using Game.Factory;
using Game.Player;
using UnityEngine;

namespace Game.Commands.Level
{
    public class CreatePlayerCommand : ICommand
    {
        private readonly Transform _parent;

        private PlayerController _player;

        public CreatePlayerCommand(Transform parent)
        {
            _parent = parent;
        }

        public PlayerController Player
        {
            get { return _player; }
        }

        public void Execute()
        {
            GameFactory factory = BindManager.GetInstance<GameFactory>();
            _player = factory.CreatePlayer();
            
            _player.CachedTransform.parent = _parent;
            _player.CachedTransform.position = Vector3.zero;
            _player.CachedTransform.localScale = Vector3.one;
        }
    }
}