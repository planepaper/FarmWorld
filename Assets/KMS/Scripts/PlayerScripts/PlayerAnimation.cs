using UnityEngine;
public enum ActionState
{
    Idle,
    Walk,
    Pull,
    Down
};

public class PlayerAnimation : MonoBehaviour
{
    private ActionState actionState = ActionState.Idle;
    private Animator animator;

    private void PullAnimation()
    {
        //actionState = ActionState.Pull;
        //animator.SetBool("Pull", true);
    }

    private void DownAnimation()
    {
        actionState = ActionState.Down;
        animator.SetBool("Down", true);
    }

    private void WalkAniamtion()
    {
        // 이동시에 제어해야할까?
        actionState = ActionState.Walk;
        animator.SetBool("Walk", true);
    }

    public void ChangePlayerState(ActionState actionState)
    {
        switch (actionState)
        {
            case ActionState.Idle:
                break;
            case ActionState.Walk:
                WalkAniamtion();
                break;
            case ActionState.Pull:
                PullAnimation();
                break;
            case ActionState.Down:
                DownAnimation();
                break;
        }
    }

    public ActionState GetPlayerAction()
    {
        return actionState;
    }
}
