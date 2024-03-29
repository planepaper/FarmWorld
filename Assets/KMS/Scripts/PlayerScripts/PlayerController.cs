using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

using CJ.Scripts.GamePlay;
using CJ.Scripts.StockMarket.UI;
using CJ.Scripts.StockMarket;

enum PlayerPlace
{
    Outside, Fence, House
}

public class PlayerController : MonoBehaviour
{
    PlayerAnimation playerAnimation;
    PlayerData playerData;
    Move playerMove;
    playerActionState currentState = playerActionState.Idle;

    [SerializeField]
    PlayerPlace playerPlace = PlayerPlace.Outside;

    private List<TestVege> nearTarget = new List<TestVege>();

    public float _Speed { get => playerData.speed; }

    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerData = GetComponent<PlayerData>();
        playerMove = GetComponent<Move>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Crop")
        {
            nearTarget.Add(other.gameObject.GetComponent<TestVege>());
        }
        else if (other.tag == "Fence")
        {
            playerPlace = PlayerPlace.Fence;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Crop")
        {
            for (int i = 0; i < nearTarget.Count; i++)
            {
                if (ReferenceEquals(nearTarget[i], other.GetComponent<TestVege>()))
                {
                    nearTarget.RemoveAt(i);
                }
            }
        }
        else if (other.tag == "Fence")
        {
            playerPlace = PlayerPlace.Outside;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "House")
        {
            playerPlace = PlayerPlace.House;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "House")
        {
            playerPlace = PlayerPlace.Fence;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.Instance.isRunning)
        {
            if (nearTarget.Count > 0)
            {
                // 잡기가 실패하면 그냥 리턴
                TestVege nearest = nearTarget[nearTarget.Count - 1];
                if (!GameManager.Instance.TryCatchCrop(nearest.GetID(), nearest.gameObject))
                {
                    return;
                }
                nearest.PickIt(transform);
            }
            else
            {
                if (playerPlace == PlayerPlace.House)
                {
                    GameManager.Instance.SellInventoryCrops();
                    DeleteAllTestVeges();
                }
                else
                {
                    var go = GameManager.Instance.TryUnCatchCrops();
                    if (go != null)
                    {
                        var vegetableOnHand = go.GetComponent<TestVege>();
                        if (playerPlace == PlayerPlace.Fence)
                        {
                            vegetableOnHand.DropItOnInnerFence();
                        }
                        else
                        {
                            vegetableOnHand.DropItToOutside();
                        }
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

    void DeleteAllTestVeges()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        transform.DetachChildren();
    }

    public void ChangeMove(float value, float value2)
    {
        playerAnimation.SetMoveY(value, value2);
    }
}
