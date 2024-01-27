using UnityEngine;
using UnityEngine.UI;
public enum playerActionState
{
    Idle,
    Walk,
};

public class PlayerAnimation : MonoBehaviour
{
    private playerActionState actionState = playerActionState.Idle;
    private Animator animator;
    private float moveY;
    private float moveX;

    PlayerController playerController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    private void WalkAniamtion()
    {
        // 이동시에 제어해야할까?
        actionState = playerActionState.Walk;
        animator.SetBool("Walk", true);
    }

    private void IdleAnimation()
    {
        actionState = playerActionState.Idle;
        animator.SetBool("Walk", false);
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

    public void SetMoveY(float moveValue, float moveValue2)
    {
        moveX = moveValue2;
        moveY = moveValue;
        moveValue = filpValue(moveValue);
        moveValue2 = filpValue(moveValue2);

        animator.SetFloat("TempMove", moveValue + moveValue2);
        animator.SetFloat("MoveY", moveY);
    }

    public float filpValue(float value)
    {
        if (value < 0f)
            value *= -1f;

        return value;
    }
    public playerActionState GetPlayerState()
    {
        return actionState;
    }
}
