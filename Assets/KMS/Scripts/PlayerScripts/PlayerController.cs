using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerAnimation playerAnimation;
    PlayerData playerData;
    Move playerMove;
    playerActionState currentState = playerActionState.Idle;

    public float _Speed {get => playerData.speed;}

    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerData = GetComponent<PlayerData>();
        playerMove = GetComponent<Move>();
    }

    public void ChangePlayerState(playerActionState actionState)
    {
        playerAnimation.ChangePlayerState(actionState);
    }

    public playerActionState GetCurrentState()
    {
        currentState = playerAnimation.GetPlayerState();
        return currentState;
    }
}
