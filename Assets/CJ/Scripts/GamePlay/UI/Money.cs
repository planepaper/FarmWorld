using CJ.Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = GameManager.Instance.money.ToString();
    }
}
