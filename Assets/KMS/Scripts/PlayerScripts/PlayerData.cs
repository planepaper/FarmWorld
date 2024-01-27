using CJ.Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] TestVege nearTarget = null;

    public GameObject fullnotifyPopUpPrefab;
    private GameObject notifyPopUp = null;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out TestVege vege))
        {
            nearTarget = vege;
            vege.OpenUi();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TestVege vege))
        {
            nearTarget = null;
            vege.CloseUi();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interaction(nearTarget);
        }
    }

    private void Interaction(TestVege target)
    {
        if (target != null)
        {
            ((iInteraction) target).InteractionWork(transform);
        }
        else
        {
            {
                var go = GameManager.Instance.TryUnCatchCrops();
                if (go != null)
                {
                    (go.GetComponent<iInteraction>()).InteractionWork(transform);
                }
            }
        }
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
