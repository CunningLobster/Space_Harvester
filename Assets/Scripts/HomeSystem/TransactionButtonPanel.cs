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
    }
}