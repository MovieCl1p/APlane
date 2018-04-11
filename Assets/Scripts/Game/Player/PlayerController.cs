using Core;
using Core.Binder;
using Core.Dispatcher;
using Game.Player.Control;
using UnityEngine;

namespace Game.Player
{
    public class PlayerController : MonoScheduledBehaviour
    {
        private Camera _camera;

        [SerializeField]
        private float _moveVelocity = 40;

        private IDispatcher _dispatcher;
        private IPlayerControl _control;
        private MovementComponent _move;

        protected override void Awake()
        {
            base.Awake();
            
            _dispatcher = BindManager.GetInstance<IDispatcher>();
            _control = BindManager.GetInstance<IPlayerControl>();
            _control.OnTouch += OnTouch;
        }

        public void SetCamera(Camera playerCamera)
        {
            _move = new MovementComponent(CachedTransform, playerCamera);
        }
        
        protected override void Update()
        {
            base.Update();

            if (_move != null)
            {
                _move.MovePlayer(_moveVelocity, Time.deltaTime);
            }
        }

        private void OnTouch(Vector2 mousePosition)
        {
            if (_move != null)
            {
                _move.Rotate(Time.deltaTime);
            }
        }

        protected override void OnReleaseResources()
        {
            _control.OnTouch -= OnTouch;
            base.OnReleaseResources();
        }
    }
}
