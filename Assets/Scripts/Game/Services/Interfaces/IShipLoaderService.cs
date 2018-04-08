using Game.Player;

namespace Game.Services.Interfaces
{
    public interface IShipLoaderService
    {
        PlayerController GetShip(int ShipId);
    }
}
