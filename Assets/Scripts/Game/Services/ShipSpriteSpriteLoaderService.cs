using Core.ResourceManager;
using Game.Config;
using Game.Data;
using Game.Services.Interfaces;
using UnityEngine;

namespace Game.Services
{
    public class ShipSpriteSpriteLoaderService : IShipSpriteLoaderService
    {
        public Texture2D GetSprite(string spriteId)
        {
            GameConfig config = ResourcesCache.GetConfig<GameConfig>(ConfigData.GameConfigPath);
            return config.GetShipSprite(spriteId);
        }
    }
}
