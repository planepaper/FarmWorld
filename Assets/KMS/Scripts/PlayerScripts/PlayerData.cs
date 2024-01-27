using CJ.Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float speed = 5f;

    public GameObject fullnotifyPopUpPrefab;
    private GameObject notifyPopUp = null;

    private void Start()
    {
    }

    IEnumerator ShowFullPopUp()
    {
        if (notifyPopUp == null)
        {
            notifyPopUp = Instantiate(fullnotifyPopUpPrefab);
        }
        yield return new WaitForSeconds(2f);
        Destroy(notifyPopUp);
    }
}
