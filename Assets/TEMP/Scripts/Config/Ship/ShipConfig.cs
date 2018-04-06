using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Config.Ship
{
    public class ShipConfig : ScriptableObject, IShipConfig
    {
        public string ShipName;
        public int ShipId;
        public Sprite Icon;
        public GameObject ShipPrefab;

        //public List<ShipConfig> ships;

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
    }
}
