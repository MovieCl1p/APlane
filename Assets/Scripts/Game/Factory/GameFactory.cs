using System;
using Control;
using Core.ResourceManager;
using Game.Player;
using UnityEngine;
using Game.Asteroid;

namespace Game.Factory
{
    public class GameFactory
    {
        public PlayerController GetPlayer()
        {
//            if (!ResourcesCache.IsResourceLoaded("Player"))
//            {
//                ResourcesCache.SetupResourcesCache("Player", "Game/Player");
//            }
//
//            var prefab = ResourcesCache.GetObject<PlayerController>("Player", "Player");
//            PlayerController player = GameObject.Instantiate<PlayerController>(prefab);
//
//            return player;

            return null;
        }
        
        public RocketController GetRocket()
        {
//            if (!ResourcesCache.IsResourceLoaded("Rocket"))
//            {
//                ResourcesCache.SetupResourcesCache("Rocket", "Game/Rocket");
//            }
//
//            var prefab = ResourcesCache.GetObject<RocketController>("Rocket", "Rocket");
//            RocketController rocket = GameObject.Instantiate<RocketController>(prefab, GetRocketPosition(), Quaternion.identity);

//            return rocket;

            return null;
        }

        public AsteroidController GetAsteroid()
        {
//            if (!ResourcesCache.IsResourceLoaded("Asteroid 1"))
//            {
//                ResourcesCache.SetupResourcesCache("Asteroid 1", "Game/Asteroid");
//            }
//
//            var prefab = ResourcesCache.GetObject<AsteroidController>("Asteroid 1", "Asteroid 1");
//            AsteroidController rocket = GameObject.Instantiate<AsteroidController>(prefab, GetRocketPosition(), Quaternion.identity);
//
//            return rocket;

            return null;
        }

        public Vector3 GetRocketPosition()
        {
            var dx = Screen.width + 20;
            var dy = Screen.height + 20;

            var rx = UnityEngine.Random.Range(dx, dx);
            var ry = UnityEngine.Random.Range(dy, dy);

            Vector3 pos = new Vector3(Screen.width, Screen.height, 0);

            return pos;
        }
    }
}
