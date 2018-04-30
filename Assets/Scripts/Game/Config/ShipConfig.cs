using System;
using UnityEngine;

namespace Game.Config
{
    [Serializable]
    public class ShipConfig
    {
        public Texture2D Texture;

        public string SpriteId;

        public int ShipHealth = 100;
    }
}