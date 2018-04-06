using System;
using UnityEngine;

namespace Game.Player.Control
{
    public interface IPlayerControl
    {
        event Action<Vector2> OnTouch;
    }
}
