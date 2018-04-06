using Core;
using Core.Binder;
using Core.Dispatcher;
using Game.Player.Control;
using UnityEngine;

namespace Game.Player
{
    public class ButtonPlayerController : MonoScheduledBehaviour
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
        private bool _active = true;
        private int _color1;
        private bool _grounded;

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
            _player.Translate(0,_moveVelocity, 0 * Time.deltaTime);
            
        }
        
        public void Activate(bool a)
        {
            _active = a;
        }

        private void OnLeftClick()
        {
            //_move.OnJump();

            //float angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
            float angle = 2;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            _player.rotation = Quaternion.RotateTowards(_player.rotation, targetRotation, _rotateVelocity * Time.deltaTime);
            //_player.rotation = Quaternion.Euler(0, 0, angle);

            _active = false;
        }

        private void OnRightClick()
        {
            //float angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
            float angle = 2;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            _player.rotation = Quaternion.RotateTowards(_player.rotation, targetRotation, _rotateVelocity * Time.deltaTime);
            //_player.rotation = Quaternion.Euler(0, 0, angle);

            _active = false;
        }

        public void CheckDeath(Transform platform)
        {
            //var result = _colorChecker.CheckColor(_currentColor, platform);
            //if (!result)
            //{
            //    _dispatcher.Dispatch(LevelEventsEnum.Restart);
            //    return;
            //}
        }

        public void EmitTrail(bool v)
        {
            _view.EmitTrail(v);
        }

        private void CreateParticles(float maxDist)
        {
            _view.DeathEmitParticles(maxDist);
        }

        protected override void OnReleaseResources()
        {
            base.OnReleaseResources();

            //_control.OnLeftClick -= OnLeftClick;
            //_control.OnRightClick -= OnRightClick;
        }

        public void Reset(Vector3 startPosition)
        {
            CachedTransform.position = startPosition;
            _move.Reset();
            
            _active = false;
        }

        public void OnTriggerEnter(Collider other)
        {
            //_move.CollisionEnter(other);

            int collisionLayer = other.gameObject.layer;
            if (collisionLayer == _color1)
            {
                _grounded = true;

                //_player.EmitTrail(true);

                //_player.CheckDeath(other.transform);
            }
        }

        public void OnTriggerStay(Collider other)
        {
            //_move.CollisionStay(other);

            int collisionLayer = other.gameObject.layer;
            if (collisionLayer == _color1)
            {
                //_player.CheckDeath(other.transform);
            }
        }

        public void OnTriggerExit(Collider other)
        {
            //_move.CollisionExit(other);

            int collisionLayer = other.gameObject.layer;
            if (collisionLayer == _color1)
            {
                _grounded = false;
            }
        }
    }
}
