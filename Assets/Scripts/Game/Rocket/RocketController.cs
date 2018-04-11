using Game.Pool;
using UnityEngine;
using System;
using Core;

namespace Game.Rocket
{
    public class RocketController : BaseMonoBehaviour, IPoolable
    {
        private Transform _target;

        [SerializeField]
        private float _moveVelocity = 50;

        [SerializeField]
        private float _rotateVelocity = 360;

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
    }
}
