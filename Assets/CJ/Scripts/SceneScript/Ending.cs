using CJ.Scripts.Audio;
using CJ.Scripts.Common;
using CJ.Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ending : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject[] contents;
    [SerializeField] private TMP_Text finalScore;

    private int contentCount = 0;

    // Start is called before the first frame update
    void OnEnable()
    {
        BgmManager.Instance.Play(BgmType.Ending);
        finalScore.text = GameManager.Instance.money.ToString();

        contents[contentCount].SetActive(true);
    }

    void GoToMain()
    {
        SceneManager.LoadScene(SceneType.MainMenu);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        contents[contentCount].SetActive(false);
        contentCount++;

        if (contentCount < contents.Length)
        {
            contents[contentCount].SetActive(true);
        }
        else
        {
            GoToMain();
        }
    }
}
