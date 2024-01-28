using CJ.Scripts.Audio;
using CJ.Scripts.Common;
using CJ.Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject credit;
    [SerializeField] private TMP_Text finalScore;

    private int contentCount = 0;

    // Start is called before the first frame update
    void OnEnable()
    {
        BgmManager.Instance.Play(BgmType.Ending);
        finalScore.text = GameManager.Instance.money.ToString();
    }

    public void GoToMain()
    {
        SfxManager.Instance.Play(SfxType.Button);
        SceneManager.LoadScene(SceneType.MainMenu);
    }

    public void CreditOnOff(bool forward)
    {
        SfxManager.Instance.Play(SfxType.Button);
        credit.gameObject.SetActive(forward);
    }
}
