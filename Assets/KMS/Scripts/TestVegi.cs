using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVegi : MonoBehaviour, iInteraction
{
    public SpriteRenderer PopUp;
    public void OpenUi()
    {
        if (PopUp.enabled == false)
        {
            PopUp.enabled = true;
        }
    }
    public void CloseUi()
    {
        if (PopUp.enabled == true)
        {
            PopUp.enabled = false;
        }
    }

    public void InteractionWork(Transform player)
    {
        transform.SetParent(player.transform);
        CloseUi();
    }
}
