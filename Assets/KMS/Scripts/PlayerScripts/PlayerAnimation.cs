using UnityEngine;
public enum playerActionState
{
    Idle,
    Walk,
};

public class PlayerAnimation : MonoBehaviour
{
    private playerActionState actionState = playerActionState.Idle;
    private Animator animator;

    PlayerController playerController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    private void WalkAniamtion()
    {
        // 이동시에 제어해야할까?
        //actionState = playerActionState.Walk;
        //animator.SetBool("Walk", true);
    }

    private void IdleAnimation()
    {
        //actionState = playerActionState.Idle;
        //animator.SetBool("Walk", false);
    }
    public void ChangePlayerState(playerActionState actionState)
    {
        switch (actionState)
        {
            case playerActionState.Idle:
                IdleAnimation();
                break;
            case playerActionState.Walk:
                WalkAniamtion();
                break;
        }
    }

    public playerActionState GetPlayerState()
    {
        return actionState;
    }
}
