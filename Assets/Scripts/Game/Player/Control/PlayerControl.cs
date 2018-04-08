
using Core.UnityUtils;
using System;
using UnityEngine;

namespace Game.Player.Control
{
    public class PlayerControl : IPlayerControl, IUpdateHandler
    {
        public event Action<Vector2> OnTouch;
        
        public bool IsUpdating { get; set; }

        public bool IsRegistered { get; set; }
        
        public PlayerControl()
        {
            UpdateNotifier.Instance.Register(this);
        }

        public void OnUpdate()
        {
            if(Input.GetMouseButton(0))
            {
                CallTouch();
            }
        }

        private void CallTouch()
        {
            if(OnTouch != null)
            {
                OnTouch(Input.mousePosition);
            }
        }
    }
}
