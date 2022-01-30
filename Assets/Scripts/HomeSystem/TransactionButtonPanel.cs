using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceCarrier.HomeSystem
{
    public class TransactionButtonPanel : MonoBehaviour
    {
        [SerializeField] Button Sell1Button;
        [SerializeField] Button Sell10Button;
        [SerializeField] Button Sell100Button;

        [SerializeField] Button Buy1Button;
        [SerializeField] Button Buy10Button;
        [SerializeField] Button Buy100Button;

        [SerializeField] Button DealButton;
        [SerializeField] Button SellAllButton;

        [SerializeField] TradeZone tradeZone;

        private void Start()
        {
            Sell1Button.onClick.AddListener(delegate { tradeZone.OnChangeBalance(-1); });
            Sell10Button.onClick.AddListener(delegate { tradeZone.OnChangeBalance(-10); });
            Sell100Button.onClick.AddListener(delegate { tradeZone.OnChangeBalance(-100); });

            Buy1Button.onClick.AddListener(delegate { tradeZone.OnChangeBalance(1); });
            Buy10Button.onClick.AddListener(delegate { tradeZone.OnChangeBalance(10); });
            Buy100Button.onClick.AddListener(delegate { tradeZone.OnChangeBalance(100); });

            DealButton.onClick.AddListener(delegate { tradeZone.OnDealButton(); });
        }
    }
}