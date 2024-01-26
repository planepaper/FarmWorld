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

    // �÷��̾� ���¿� ���� �ִϸ��̼� ����

    // ���ͷ��� ����� �Լ�

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
