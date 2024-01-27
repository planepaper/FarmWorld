using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;
using CJ.Scripts.Common;
using CJ.Scripts.GamePlay.UI;
using CJ.Scripts.GamePlay;

public class House : MonoSingleton<House>
{
    const int maxVegeCounts = 10;

    public Canvas CanvasPrefab;
    private Canvas currentCanvas = null;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            OpenUi();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            CloseUi();
        }
    }

    public void OpenUi()
    {
        if (currentCanvas == null)
        {
            var canvas = Instantiate(CanvasPrefab, this.transform);
            canvas.transform.position = new Vector2(transform.position.x, transform.position.y + 2.5f);
            currentCanvas = canvas;
        }
        currentCanvas.enabled = true;
    }
    public void CloseUi()
    {
        currentCanvas.enabled = false;
    }

    // public void GiveFenceVege(TestVege vege)
    // {
    //     if (testVeges.Count < maxVegeCounts)
    //     {
    //         testVeges.Add(vege);
    //         GameManager.Instance.TryUnCatchCrops();
    //     }
    // }

    // public TestVege TakeVegeFromFence(TestVege vege)
    // {
    //     if (testVeges.Count > 0)
    //     {
    //         testVeges.remove(vege);
    //         GameManager.Instance.TryUnCatchCrops();
    //     }
    //     testVeges.Add(vege);
    //     GameManager.Instance.TryUnCatchCrops();
    // }
}
