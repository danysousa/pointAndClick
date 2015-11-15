<<<<<<< HEAD
using System;
using UnityEngine;


namespace UnityStandardAssets.Effects
{
    public class ExtinguishableParticleSystem : MonoBehaviour
    {
        public float multiplier = 1;

        private ParticleSystem[] m_Systems;


        private void Start()
        {
            m_Systems = GetComponentsInChildren<ParticleSystem>();
        }


        public void Extinguish()
        {
            foreach (var system in m_Systems)
            {
                system.enableEmission = false;
            }
        }
    }
}
=======
using System;
using UnityEngine;


namespace UnityStandardAssets.Effects
{
    public class ExtinguishableParticleSystem : MonoBehaviour
    {
        public float multiplier = 1;

        private ParticleSystem[] m_Systems;


        private void Start()
        {
            m_Systems = GetComponentsInChildren<ParticleSystem>();
        }


        public void Extinguish()
        {
            foreach (var system in m_Systems)
            {
                system.enableEmission = false;
            }
        }
    }
}
>>>>>>> 6d09be22fa957992b0c260655a72c7da0594e28a
