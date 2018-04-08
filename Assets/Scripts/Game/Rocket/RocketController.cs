using Game.Pool;
using UnityEngine;
using System;

namespace Control
{
    public class RocketController : MonoBehaviour, IPoolable
    {
        private Transform _target;
        private Transform _cachedTransform;

        [SerializeField]
        private float _moveVelocity = 50;

        [SerializeField]
        private float _rotateVelocity = 40;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            MoveRocket();
            RotateRocket();
        }

        private void RotateRocket()
        {
            var offset = new Vector2(_target.position.x - _cachedTransform.position.x, _target.position.y - _cachedTransform.position.y);
            var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            _cachedTransform.rotation = Quaternion.Euler(0, 0, angle);

            //Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            //_cachedTransform.rotation = Quaternion.RotateTowards(_cachedTransform.rotation, targetRotation, _rotateVelocity * Time.deltaTime);
        }

        private void MoveRocket()
        {
            _cachedTransform.Translate(Vector3.up * (_moveVelocity * Time.deltaTime));
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public void OnSpawn()
        {
            
        }
    }
}
