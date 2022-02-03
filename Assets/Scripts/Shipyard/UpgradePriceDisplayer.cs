using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePriceDisplayer : MonoBehaviour
{
    [SerializeField] private Image[] images;
    [SerializeField] private TMP_Text[] prices;

    public void ShowUpgradePrice(List<Sprite> sprites, List<int> prices)
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            images[i].sprite = sprites[i];
            this.prices[i].text = prices[i].ToString();
        }
    }
}
