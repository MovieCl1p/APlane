using Core;
using Game.Components;
using UnityEngine;

namespace Game.Rocket
{
    public class RocketColliderHandler : BaseMonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            IDamagable component = other.GetComponent<IDamagable>();
            if (component != null)
            {
                component.ApplyDamage();
            }
        }
    }
}