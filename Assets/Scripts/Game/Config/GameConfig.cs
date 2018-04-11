using Game.Asteroid;
using Game.Player;
using Game.Rocket;
using UnityEngine;

namespace Game.Config
{
    public class GameConfig : ScriptableObject
    {
        public RocketController RocketPrefab;
        
        public AsteroidController AsteroidPrefab;
        
        public PlayerController PlayerPrefab;
    }
}