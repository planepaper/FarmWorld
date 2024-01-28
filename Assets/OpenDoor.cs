using CJ.Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool state = true;
    private List<GameObject> targets = new List<GameObject>();

    private void Start()
    {
        targets.Add(transform.GetChild(0).gameObject);
        targets.Add(transform.GetChild(1).gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Open();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Close();
    }
    public void Open()
    {
        foreach (var obj in targets)
        {
            obj.gameObject.SetActive(false);
        }
    }

    public void Close()
    {
        foreach (var obj in targets)
        {
            obj.gameObject.SetActive(true);
        }
    }
}
