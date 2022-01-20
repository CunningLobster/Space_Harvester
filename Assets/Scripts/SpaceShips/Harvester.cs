using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using SpaceCarrier.Celestials;
using UnityEngine.InputSystem;

namespace SpaceCarrier.SpaceShips
{
    public class Harvester : MonoBehaviour
    {
        [SerializeField] Cargo cargo;
        public Cargo Cargo { get => cargo; }

        [SerializeField] float harvestDelay = .5f;
        [SerializeField] int productivity = 5;
        CelestialResources source;

        public bool isHarvesting = false;

        IEnumerator Harvest()
        {

            while (source.CurrentResource > 0)
            {
                yield return new WaitForSeconds(harvestDelay);
                source.Loose(productivity);
                cargo.Fill(productivity, source.ResourceType);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<CelestialResources>(out CelestialResources source)) return;
            if (isHarvesting) return;

            print("entered " + other.gameObject.name);
            this.source = source;
            StartCoroutine(Harvest());
            isHarvesting = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (source == null) return;
            if (other.gameObject != source.gameObject) return;
            StopAllCoroutines();
            isHarvesting = false;
        }

        private void Update()
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
                cargo.ResetResources();
        }
    }
}
