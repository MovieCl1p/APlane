using Core;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Player
{
    public class PlayerView : BaseMonoBehaviour
    {
        [SerializeField]
        private Renderer _renderers;
        
        [SerializeField]
        private ParticleSystem _engineParticle;
        [SerializeField]
        private ParticleSystem _sparksParticle;

        [SerializeField]
        private ParticleSystem _deathParticles;

        private ParticleSystem _activeTrail;
        
        protected override void Start()
        {
            base.Start();
            
        }

        public void ChangeColor(int layer)
        {
            ParticleSystem particle = layer == -1 ? _engineParticle : _sparksParticle;
            bool first = layer == -1;

            //_renderers. = particle;

            SwitchTrail(first);
        }

        public void DeathEmitParticles(float maxDist)
        {
            _deathParticles.Emit(4);
        }

        public void EmitTrail(bool active)
        {
            if (_activeTrail != null)
            {
                if (active)
                {
                    _activeTrail.Play();
                }
                else
                {
                    _activeTrail.Stop(false, ParticleSystemStopBehavior.StopEmitting);
                }
            }
        }

        private bool _lastAirActive = false;

        public void EmitTrailInAir(bool active)
        {
            if (_lastAirActive != active)
            {
                EmitTrail(active);
                _lastAirActive = active;
            }
        }
        
        private void SwitchTrail(bool first)
        {
            if (_activeTrail != null)
            {
                _activeTrail.Stop(false, ParticleSystemStopBehavior.StopEmitting);
            }

            _activeTrail = first ? _engineParticle : _sparksParticle;
        }
    }
}
