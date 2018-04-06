using Core;
using Core.Binder;
using Core.Dispatcher;
using Game.Player.Control;
using UnityEngine;

namespace Game.Player
{
    public class ClickPlayerController : MonoScheduledBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _player;
        [SerializeField] private PlayerView _view;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _moveVelocity = 1;
        [SerializeField] private float _rotateVelocity = 4;

        private MovementComponent _move;
        private IDispatcher _dispatcher;
        private IPlayerControl _control;

        private int _color1;
        private bool _grounded;
        private bool _active = true;

        private void Awake()
        {
            base.Awake();

            _dispatcher = BindManager.GetInstance<IDispatcher>();
            _control = BindManager.GetInstance<IPlayerControl>();
            //_control.OnLeftClick += OnLeftClick;
            //_control.OnRightClick += OnRightClick;

            //_move = new MovementComponent(this, _groundMask);
        }

        private void FixedUpdate()
        {
            base.Update();

            Move();
            if (!_active)
            {
                return;
            }

            //_move.Update(Time.deltaTime);
        }

        public void Move()
        {
            _active = true;

            _player.Translate(0, _moveVelocity, 0 * Time.deltaTime);

            if (_active)
            {
                var _pos = _camera.ScreenToViewportPoint(Input.mousePosition);

                var direct = new Vector2(_pos.x - _player.position.x, _pos.y - _player.position.y);

                float angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;

                Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
                _player.rotation = Quaternion.RotateTowards(_player.rotation, targetRotation, _rotateVelocity * Time.deltaTime);
                //_player.rotation = Quaternion.Euler(0, 0, angle);

                _active = false;
            }
        }
    }
}
