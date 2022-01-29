using SpaceCarrier.Celestials;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceCarrier.SpaceShips
{
    public class Harvester : MonoBehaviour
    {
        [SerializeField] private Cargo cargo;
        public Cargo Cargo { get => cargo; }

        [SerializeField] private float harvestDelay = .5f;
        [SerializeField] private int productivity = 5;
        private CelestialResources source;
        private bool isHarvesting = false;
        private Coroutine harvestRoutine;

        private IEnumerator Harvest()
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
            harvestRoutine = StartCoroutine(Harvest());
            isHarvesting = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (source == null) return;
            if (other.gameObject != source.gameObject) return;

            if (harvestRoutine != null)
                StopCoroutine(harvestRoutine);

            isHarvesting = false;
        }

        public void OnDie()
        {
            if (harvestRoutine != null)
                StopCoroutine(harvestRoutine);
            Cargo.ResetResources();
            enabled = false;
        }
    }
}
