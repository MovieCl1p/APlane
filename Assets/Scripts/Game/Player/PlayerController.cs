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

        [SerializeField]
        private float _rotateVelocity = 40;

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
                //_move.RotatePlayer();
                _move.Rotate(_rotateVelocity, Time.deltaTime);
            }
        }
        
        public void SetCamera(Camera camera)
        {
            _camera = camera;
            _move = new MovementComponent(transform, _camera);
        }
    }
}
