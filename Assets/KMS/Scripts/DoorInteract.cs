using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
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


    private void Open()
    {
        foreach (var item in targets)
        {
            item.SetActive(false);
        }
    }

    private void Close()
    {
        foreach (var item in targets)
        {
            item.SetActive(true);
        }
    }
}
