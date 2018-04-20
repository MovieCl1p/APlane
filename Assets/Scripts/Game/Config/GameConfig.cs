using System.Collections.Generic;
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

        public List<ShipConfig> ShipConfigs;

        public Texture2D GetShipSprite(string spriteId)
        {
            for (int i = 0; i < ShipConfigs.Count; i++)
            {
                if (ShipConfigs[i].SpriteId == spriteId)
                {
                    return ShipConfigs[i].Texture;
                }
            }

            return null;
        }
    }
}