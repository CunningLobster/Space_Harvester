using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceCarrier.SpaceShips
{
    public class ShipAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource thrustSource;
        [SerializeField] private AudioSource eventAudioSource;

        [SerializeField] private AudioClip explosionAudioClip;
        [SerializeField] private AudioClip harvestingAudioClip;

        [SerializeField] private AudioClip hyperJumpChargingClip;
        [SerializeField] private AudioClip hyperJumpJumpingClip;
        [SerializeField] private AudioClip hyperJumpSlowDownClip;

        bool isThrusting;
        bool a = true;
        public void PlayThrustAudioEffect(Vector3 movingVector)
        {
            if (movingVector == Vector3.zero)
            {
                thrustSource.pitch = 0.1f;
                isThrusting = true;
                return;
            }
            if(isThrusting) 
            {
                isThrusting = false;
            }
            thrustSource.pitch = movingVector.sqrMagnitude * 1.5f;
        }

        public void PlayExplosionAudioEffect()
        {
            thrustSource.Stop();
            eventAudioSource.PlayOneShot(explosionAudioClip);
        }

        public void PlayHarvestingAudioClip()
        {
            eventAudioSource.PlayOneShot(harvestingAudioClip);
        }

        public void PlayHyperJumpChargingClip(bool isJumping)
        {
            if (!isJumping && !a)
            {
                eventAudioSource.Stop();
                PlayHyperJumpSlowDownClip();
                a = true;
                return;
            }

            else if(isJumping && a)
            {
                eventAudioSource.PlayOneShot(hyperJumpChargingClip);
                a = false;
            }
        }

        public void PlayHyperJumpSlowDownClip()
        {
            eventAudioSource.PlayOneShot(hyperJumpSlowDownClip);
        }

        public void PlayHyperJumpJumpingClip()
        {
            eventAudioSource.PlayOneShot(hyperJumpJumpingClip);
        }
    }
}
