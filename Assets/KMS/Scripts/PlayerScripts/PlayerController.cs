using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

using CJ.Scripts.GamePlay;

public class PlayerController : MonoBehaviour
{
    PlayerAnimation playerAnimation;
    PlayerData playerData;
    Move playerMove;
    playerActionState currentState = playerActionState.Idle;
    bool isHeInFence = false;

    private TestVege nearTarget = null;

    public float _Speed { get => playerData.speed; }

    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerData = GetComponent<PlayerData>();
        playerMove = GetComponent<Move>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out TestVege vege))
        {
            nearTarget = vege;
        }
        if (other.tag == "Fence")
        {
            isHeInFence = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out TestVege vege))
        {
            nearTarget = null;
        }
        if (other.tag == "Fence")
        {
            isHeInFence = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (nearTarget != null)
            {
                // 잡기가 실패하면 그냥 리턴
                if (!GameManager.Instance.TryCatchCrop(nearTarget.GetID(), nearTarget.gameObject))
                {
                    return;
                }
                nearTarget.PickIt(transform);
            }
            else
            {
                var go = GameManager.Instance.TryUnCatchCrops();
                if (go != null)
                {
                    if (isHeInFence)
                    {
                        go.GetComponent<TestVege>().DropItOnInnerFence();

                    }
                    else
                    {
                        go.GetComponent<TestVege>().DropItToOutside();
                    }
                }
            }
        }
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
