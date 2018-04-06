using Game.Config.Ship;
using System.Collections.Generic;

namespace Game.Services.Interfaces
{
    public interface IShipService
    {
        List<ShipConfig> GetShips();

        ShipConfig GetShip(int shipId);
    }
}
