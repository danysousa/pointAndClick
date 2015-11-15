<<<<<<< HEAD
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Effects
{
    public class SmokeParticles : MonoBehaviour
    {
        public AudioClip[] extinguishSounds;


        private void Start()
        {
            GetComponent<AudioSource>().clip = extinguishSounds[Random.Range(0, extinguishSounds.Length)];
            GetComponent<AudioSource>().Play();
        }
    }
}
=======
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Effects
{
    public class SmokeParticles : MonoBehaviour
    {
        public AudioClip[] extinguishSounds;


        private void Start()
        {
            GetComponent<AudioSource>().clip = extinguishSounds[Random.Range(0, extinguishSounds.Length)];
            GetComponent<AudioSource>().Play();
        }
    }
}
>>>>>>> 6d09be22fa957992b0c260655a72c7da0594e28a
