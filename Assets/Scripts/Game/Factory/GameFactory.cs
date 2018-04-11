using Core.ResourceManager;
using Game.Player;
using UnityEngine;
using Game.Asteroid;
using Game.Config;
using Game.Data;
using Game.Rocket;

namespace Game.Factory
{
    public class GameFactory
    {
        public PlayerController CreatePlayer()
        {
            GameConfig config = ResourcesCache.GetConfig<GameConfig>(ConfigData.GameConfigPath);
            PlayerController result = GameObject.Instantiate<PlayerController>(config.PlayerPrefab);

            return result;
        }
        
        public RocketController CreateRocket()
        {
            GameConfig config = ResourcesCache.GetConfig<GameConfig>(ConfigData.GameConfigPath);
            RocketController result = GameObject.Instantiate<RocketController>(config.RocketPrefab);

            return result;
        }

        public AsteroidController CreateAsteroid()
        {
            GameConfig config = ResourcesCache.GetConfig<GameConfig>(ConfigData.GameConfigPath);
            AsteroidController result = GameObject.Instantiate<AsteroidController>(config.AsteroidPrefab);

            return result;
        }
    }
}
