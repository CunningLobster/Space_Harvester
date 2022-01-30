using SpaceCarrier.Celestials;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceCarrier.HomeSystem
{
    public class ResourcePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text credits;
        [SerializeField] private TMP_Text purple;
        [SerializeField] private TMP_Text red;
        [SerializeField] private TMP_Text blue;
        [SerializeField] private TMP_Text green;
        [SerializeField] private TMP_Text brown;

        //Panel with credits
        public void UpdatePanel(int credits, int purple, int red, int blue, int green, int brown)
        {
            this.credits.text = credits.ToString();
            this.purple.text = purple.ToString();
            this.red.text = red.ToString();
            this.blue.text = blue.ToString();
            this.green.text = green.ToString();
            this.brown.text = brown.ToString();
        }

        //Panel without credits
        public void UpdatePanel(int purple, int red, int blue, int green, int brown)
        {
            this.purple.text = purple.ToString();
            this.red.text = red.ToString();
            this.blue.text = blue.ToString();
            this.green.text = green.ToString();
            this.brown.text = brown.ToString();
        }

        //Dictionary Based Panel
        public void UpdatePanel(Dictionary<ResourceTypes, int> resources, int credits)
        {
            this.credits.text = credits.ToString();
            this.purple.text = resources[ResourceTypes.Purple].ToString();
            this.red.text = resources[ResourceTypes.Red].ToString();
            this.blue.text = resources[ResourceTypes.Blue].ToString();
            this.green.text = resources[ResourceTypes.Green].ToString();
            this.brown.text = resources[ResourceTypes.Brown].ToString();
        }
        public void UpdatePanel(Dictionary<ResourceTypes, int> resources)
        {
            this.purple.text = resources[ResourceTypes.Purple].ToString();
            this.red.text = resources[ResourceTypes.Red].ToString();
            this.blue.text = resources[ResourceTypes.Blue].ToString();
            this.green.text = resources[ResourceTypes.Green].ToString();
            this.brown.text = resources[ResourceTypes.Brown].ToString();
        }
    }
}