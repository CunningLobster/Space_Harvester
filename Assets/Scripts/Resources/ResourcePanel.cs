using SpaceCarrier.Celestials;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace SpaceCarrier.Resoures
{
    public class ResourcePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text credits;
        [SerializeField] private TMP_Text purple;
        [SerializeField] private TMP_Text red;
        [SerializeField] private TMP_Text blue;
        [SerializeField] private TMP_Text green;
        [SerializeField] private TMP_Text brown;

        Dictionary<ResourceTypes, TMP_Text> panelResources = new Dictionary<ResourceTypes, TMP_Text>();
        public TMP_Text Credits { get => credits; set => credits = value; }
        public Dictionary<ResourceTypes, TMP_Text> PanelResources { get => panelResources; private set => panelResources = value; }

        private void Awake()
        {
            panelResources[ResourceTypes.Purple] = purple;
            panelResources[ResourceTypes.Red] = red;
            panelResources[ResourceTypes.Blue] = blue;
            panelResources[ResourceTypes.Green] = green;
            panelResources[ResourceTypes.Brown] = brown;
        }

        //Update panel with credits
        public void UpdatePanel(Dictionary<ResourceTypes, int> resources, int credits)
        {
            this.credits.text = credits.ToString();
            foreach (var key in resources.Keys.ToList())
            {
                panelResources[key].text = resources[key].ToString();
            }
        }
         //Update panel without credits
        public void UpdatePanel(Dictionary<ResourceTypes, int> resources)
        {
            foreach (var key in resources.Keys.ToList())
            {
                panelResources[key].text = resources[key].ToString();
            }
        }
    }
}