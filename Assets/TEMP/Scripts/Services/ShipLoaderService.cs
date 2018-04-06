using Core.Binder;
using Game.Config.Ship;
using Game.Player;
using Game.Services.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Services
{
    class ShipLoaderService : IShipLoaderService
    {
        private string _sceneName;
        private Action _callback;

        //private List<ShipConfig> ships;
        //public ShipConfig GetLevel(int shipId)
        //{
        //    for (int i = 0; i < ships.Count; i++)
        //    {
        //        if (ships[i].ShipId == shipId)
        //        {
        //            return ships[i];
        //        }
        //    }

        //    return null;
        //}
        
        public PlayerController GetShip(int shipId)
        {
            var service = BindManager.GetInstance<IShipService>();
            var ship = service.GetShip(shipId);
            if (ship == null)
            {
                Debug.LogError("There is no ship with id: " + shipId);
                return null;
            }
            
            var level = ship;

            if (level.ShipPrefab == null)
            {
                Debug.LogError("There is no ship with id: " + shipId);
                return null;
            }

            GameObject levelGo = GameObject.Instantiate(level.ShipPrefab);
            PlayerController result = levelGo.GetComponent<PlayerController>();

            return result;
        }

        

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if (arg0.name == _sceneName)
            {
                if (_callback != null)
                {
                    _callback();
                }
            }
        }
    }
}
