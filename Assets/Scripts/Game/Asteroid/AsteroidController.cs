using UnityEngine;
using System.Collections;
using Core;

namespace Game.Asteroid
{
    public class AsteroidController : BaseMonoBehaviour
    {
        [SerializeField]
        private float _moveVelocity = 5;

        [SerializeField]
        private float _rotateVelocity = 12;

        private Vector3 _direction;

        protected override void Start()
        {
            base.Start();
            AsteroidRotate();
        }

        private void AsteroidRotate()
        {
            CachedTransform.rotation = Quaternion.Euler(0, 0, (Random.insideUnitSphere * _rotateVelocity).z);
        }
        
        private void MoveAsteroid()
        {
            CachedTransform.Translate(-Vector3.left * (_moveVelocity * Time.deltaTime));
        }
    }
}