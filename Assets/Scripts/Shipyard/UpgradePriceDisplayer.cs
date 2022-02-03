using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePriceDisplayer : MonoBehaviour
{
    [SerializeField] private Image[] resourceImages;
    [SerializeField] private TMP_Text[] prices;

    public void ShowUpgradePrice(List<Sprite> sprites, List<int> prices)
    {
        for (int i = 0; i < prices.Count; i++)
        {
            resourceImages[i].gameObject.SetActive(true);
            resourceImages[i].sprite = sprites[i];

            this.prices[i].gameObject.SetActive(true);
            this.prices[i].text = prices[i].ToString();
        }
    }
    public void HideUpgradePrice(List<Sprite> sprites, List<int> prices)
    {
        for (int i = 0; i < resourceImages.Length; i++)
        {
            resourceImages[i].gameObject.SetActive(false);
            this.prices[i].gameObject.SetActive(false);
        }
    }
}
