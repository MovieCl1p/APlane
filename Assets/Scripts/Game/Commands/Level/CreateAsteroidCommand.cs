using Core.Binder;
using Core.Commands;
using Game.Asteroid;
using Game.Factory;
using UnityEngine;

namespace Game.Commands.Level
{
    public class CreateAsteroidCommand : ICommand
    {
        private readonly Vector3 _playerPosition;

        public CreateAsteroidCommand(Vector3 playerPosition)
        {
            _playerPosition = playerPosition;
        }
        
        public void Execute()
        {
            GameFactory factory = BindManager.GetInstance<GameFactory>();
            AsteroidController asteroid = factory.CreateAsteroid();
        }
    }
}