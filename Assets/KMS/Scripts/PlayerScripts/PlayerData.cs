using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    float speed = 0f;
    PlayerAnimation playerAnimation;

    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Judge Player Nearby target

    // Active PlayerAnimation // depart Player Animation

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out TestVege vege))
        {
            vege.OpenUi();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TestVege vege))
        {
            vege.CloseUi();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerAnimation.GetPlayerAction() != ActionState.Pull)
        {
            Interaction(collision.gameObject);
        }
    }

    private void Interaction(GameObject target)
    {
        if (target.TryGetComponent(out iInteraction targetInteraction))
        {
            playerAnimation.ChangePlayerState(ActionState.Pull);
            targetInteraction.InteractionWork(transform);
        }
    }
}
