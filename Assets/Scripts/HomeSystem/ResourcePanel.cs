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
    }
}