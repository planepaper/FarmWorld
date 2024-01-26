using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PriceController : MonoBehaviour
{
    [SerializeField]
    private int vegetablePrice = 0;

    [SerializeField]
    private const float refreshTime = 5f;

    [SerializeField] TextMeshProUGUI priceText;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > refreshTime)
        {
            RefreshPrice();
            UpdatePriceText();
            timer = 0f;
        }
    }

    private void RefreshPrice()
    {
        vegetablePrice = UnityEngine.Random.Range(0, 100) * 10;
    }

    private void UpdatePriceText()
    {
        priceText.text = vegetablePrice.ToString();
    }
}
