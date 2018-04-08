using UnityEngine;
using System.Collections;

namespace Game.Asteroid
{
    public class AsteroidController : MonoBehaviour
    {
        [SerializeField]
        private float _rotate;

        private void Start()
        {
            AsteroidRotate();
            
        }

        public void AsteroidRotate()
        {
            GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * _rotate;

        }
    }
}