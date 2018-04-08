using Control;
using Game.Asteroid;
using Game.Player;

namespace Game.Model
{
    public class LevelSessionModel
    {
        public PlayerController Player { get; set; }
        public RocketController Rocket { get; set; }
        public AsteroidController Asteroid { get; set; }

        public float LevelTime { get; set; }

    }
}
