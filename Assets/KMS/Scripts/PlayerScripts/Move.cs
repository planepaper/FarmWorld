using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 moveVelocity;
    PlayerAnimation playerAnimation;
    float movePower = 5f;

    private float velocityLimit = 0.3f;
    private float walkDeaccelerationOnX;
    private float walkDeaccelerationOnY;
    public float walkDeacceleration = 3f;

    SpriteRenderer playerImage;

    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerImage = GetComponent<SpriteRenderer>();
        playerImage.flipX = false;
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        moveVelocity = Vector3.zero;

        var inputX = Input.GetAxisRaw("Horizontal");
        var inputY = Input.GetAxisRaw("Vertical");


        var input = new Vector3(inputX, inputY).normalized * movePower;

        if (inputX < 0)
        {
            playerImage.flipX = true;
        }

        else if (inputX > 0)
        {
            playerImage.flipX = false;
        }

        //playerAnimation.ChangePlayerState(ActionState.Walk);

        moveVelocity = new Vector3
            (Mathf.SmoothDamp(input.x, 0, ref walkDeaccelerationOnX, walkDeacceleration),
            Mathf.SmoothDamp(input.y, 0, ref walkDeaccelerationOnY, walkDeacceleration),
                                     0);

        transform.position += moveVelocity * Time.deltaTime;
        //if (moveVelocity. < velocityLimit)
        //{
        //    rigid.velocity = Vector3.zero;
        //    rigid.angularVelocity = Vector3.zero;
        //}
    }

}
