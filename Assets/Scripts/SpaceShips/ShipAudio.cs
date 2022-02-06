using SpaceCarrier.UI;
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
        bool readyToJump = true;
        bool isJumping = false;
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

        public void PlayHyperJumpChargingClip(bool jumpStarted)
        {
            if(jumpStarted && readyToJump)
            {
                eventAudioSource.PlayOneShot(hyperJumpChargingClip);
                readyToJump = false;
            }
        }

        public void PlayHyperJumpSlowDownClip(bool jumpStarted)
        {
            if (!jumpStarted && !readyToJump)
            {
                eventAudioSource.Stop();
                FindObjectOfType<UILogDisplayer>().ClearLog();
                eventAudioSource.PlayOneShot(hyperJumpSlowDownClip);
                readyToJump = true;
            }
        }

        public void PlayHyperJumpJumpingClip()
        {
            if (isJumping) return;
            eventAudioSource.PlayOneShot(hyperJumpJumpingClip);
            isJumping = true;
        }
    }
}
