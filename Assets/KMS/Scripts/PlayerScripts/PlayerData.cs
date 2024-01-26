using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerData : MonoBehaviour
{
    float speed = 0f;
    PlayerAnimation playerAnimation;
    [SerializeField] TestVege nearTarget = null;
    List<TestVege> vegeLists = new List<TestVege>();


    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
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
        if (Input.GetKeyDown(KeyCode.Space) && nearTarget != null)
        {
            Interaction(nearTarget);
        }
    }

    private void Interaction(TestVege target)
    {
        if (vegeLists.Count < 11)
        {
            target.GetComponent<iInteraction>().InteractionWork(transform);
            vegeLists.Add(target);
        }
        else
        {
            // Full Inventory
        }
    }
}
