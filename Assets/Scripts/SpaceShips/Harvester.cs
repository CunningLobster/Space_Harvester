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

        bool isHarvesting = false;
        public Coroutine HarvestRoutine { get; private set; }

        IEnumerator Harvest()
        {

            while (source.CurrentResource > 0)
            {
                yield return new WaitForSeconds(harvestDelay);
                cargo.Fill(Mathf.Min(source.CurrentResource, productivity), source.ResourceType);
                source.Loose(productivity);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<CelestialResources>(out CelestialResources source)) return;
            if (isHarvesting) return;

            this.source = source;
            HarvestRoutine = StartCoroutine(Harvest());
            isHarvesting = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (source == null) return;
            if (other.gameObject != source.gameObject) return;

            if (HarvestRoutine != null)
                StopCoroutine(HarvestRoutine);

            isHarvesting = false;
        }

        public void OnDie()
        {
            if (HarvestRoutine != null)
                StopCoroutine(HarvestRoutine);
            Cargo.ResetResources();
            enabled = false;
        }

        private void Update()
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
                cargo.ResetResources();
        }
    }
}
