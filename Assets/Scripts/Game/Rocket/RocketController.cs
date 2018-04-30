using Game.Pool;
using UnityEngine;
using System;
using Core;
using Core.Binder;
using Core.Dispatcher;
using Game.Components;
using Game.Data;
using Game.Config;

namespace Game.Rocket
{
    public class RocketController : BaseMonoBehaviour, IPoolable, IDamagable
    {
        private Transform _target;

        [SerializeField]
        private float _moveVelocity = 5;

        [SerializeField]
        private float _rotateVelocity = 1;

        [SerializeField]
        private int _rocketDamage = 50;

        private ShipConfig _config;

        private IDispatcher _dispatcher;
        
        protected override void Start()
        {
            base.Start();
            
            _dispatcher = BindManager.GetInstance<IDispatcher>();
        }

        private void Update()
        {
            if (_target == null)
            {
                Debug.LogWarning("No target for rocket");
                return;
            }
            
            MoveRocket();
            RotateRocket();
        }

        private void RotateRocket()
        {
            var offset = _target.position - CachedTransform.position;
            var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            CachedTransform.rotation = Quaternion.Lerp(CachedTransform.rotation, targetRotation, _rotateVelocity * Time.deltaTime);
        }

        private void MoveRocket()
        {
            CachedTransform.Translate(Vector3.right * (_moveVelocity * Time.deltaTime));
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public void ApplyDamage()
        {
            //_rocketDamage -= _config.ShipHealth;

            _dispatcher.Dispatch(LevelEvent.OnRocketDestroyed);
            Destroy(gameObject);
        }

        public void SetVelocity(float dT)
        {
            _moveVelocity += UnityEngine.Random.Range(dT * 0.1f, dT);
            _rotateVelocity += UnityEngine.Random.Range((dT / 2) * 0.1f, (dT / 2));
        }
    }
}
