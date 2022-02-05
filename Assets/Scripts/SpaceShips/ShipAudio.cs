using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.SpaceShips
{
    [RequireComponent(typeof(AudioSource))]
    public class ShipAudio : MonoBehaviour
    {
        private AudioSource audioSource;

        [SerializeField] private AudioClip thrustAudioClip;
        [SerializeField] private AudioClip explosionAudioClip;
        private bool isThrusting;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayThrustAudioEffect(Vector3 movingVector)
        {
            if (movingVector == Vector3.zero)
            {
                audioSource.pitch = 0.1f;
                isThrusting = true;
                return;
            }
            if(isThrusting) 
            {
                audioSource.clip = thrustAudioClip;
                audioSource.loop = true;
                isThrusting = false;
            }
            audioSource.pitch = movingVector.sqrMagnitude * 1.5f;
        }

        public void PlayExplosionAudioEffect()
        {
            audioSource.clip = explosionAudioClip;
            audioSource.loop = false;
            audioSource.Play();
        }
    }
}
