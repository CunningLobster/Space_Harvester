using SpaceCarrier.Celestials;
using System.Collections;
using UnityEngine;

namespace SpaceCarrier.SpaceShips
{
    public class Harvester : MonoBehaviour
    {
        [SerializeField] private Cargo cargo;

        [SerializeField] private float harvestDelay = .5f;
        [SerializeField] private int productivity = 5;
        private CelestialResources source;
        private bool isHarvesting = false;
        private Coroutine harvestRoutine;

        private IEnumerator Harvest()
        {

            while (source.CurrentResource > 0 && !cargo.IsFull)
            {
                yield return new WaitForSeconds(harvestDelay);
                cargo.Fill(Mathf.Min(source.CurrentResource, productivity), source.ResourceType, out int amountToFill);
                source.Loose(amountToFill);
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
            cargo.ResetResources();
            enabled = false;
        }
    }
}
