using CJ.Scripts.Crops;
using CJ.Scripts.GamePlay;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CJ.Scripts.StockMarket.UI
{
    public class StockMarketSlot : MonoBehaviour
    {
        [SerializeField] private int id;

        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private Image _iconImg;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _value;
        [SerializeField] private Image _priceStatusImg;

        private void Awake()
        {
            GameManager.Instance.OnStockMarketUpdated += OnStockMarketUpdated;
        }

        private void OnStockMarketUpdated()
        {
            var stock = GameManager.Instance.stockMarket[id];
            var crop = CropScriptableObject.Instance.GetData(id);

            _iconImg.sprite = crop.icon;
            _value.text = stock.price.ToString();
            _priceStatusImg.sprite = _sprites[(int) stock.lastPriceStatus];
        }
    }
}
