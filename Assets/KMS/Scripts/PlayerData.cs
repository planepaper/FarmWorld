using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    float speed = 0f;


    // �÷��̾� �ֺ� ��ü �Ǵ�.

    // �÷��̾� �ִϸ��̼� �ߵ� // �ִϸ��̼��� �ٷ� �־�α�

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out iInteraction interactionTarget))
        {
            interactionTarget.InteractionWork(transform);
        }
    }


    void Interaction(GameObject target)
    {
        if (target.TryGetComponent(out iInteraction targetInteraction))
        {
            targetInteraction.InteractionWork(transform);
        }
    }
}
