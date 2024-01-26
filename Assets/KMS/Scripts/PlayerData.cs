using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    float speed = 0f;


    // 플레이어 주변 개체 판단.

    // 플레이어 애니메이션 발동 // 애니메이션은 다로 넣어두기

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
