using Game.Player;
using UnityEngine;

namespace Game.Services.Interfaces
{
    public interface IShipSpriteLoaderService
    {
        Texture2D GetSprite(string spriteId);
    }
}
