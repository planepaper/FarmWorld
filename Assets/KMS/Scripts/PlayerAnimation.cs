using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ActionState
{
    Idle,
    Walk,
    Pull,
    Down
};

public class PlayerAnimation : MonoBehaviour
{
    ActionState actionState = ActionState.Idle;

    Animator animator;

    // 플레이어 상태에 따른 애니메이션 변경

    // 인터랙션 수행시 함수

    //private void Update()
    //{
    //    actionState = ActionState.Idle;
    //}

    void PullAnimation()
    {
        animator.SetBool("Pull", true);
        actionState = ActionState.Pull;
    }

    void DownAnimation()
    {
        animator.SetBool("Down", true);
        actionState = ActionState.Down;
    }

    void ChangePlayerState(ActionState actionState)
    {
        switch (actionState)
        {
            case ActionState.Idle:
                break;
            case ActionState.Walk:
                break;
            case ActionState.Pull:
                PullAnimation();
                break;
            case ActionState.Down:
                DownAnimation();
                break;
        }
    }
}
