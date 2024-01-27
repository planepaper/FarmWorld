using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer background;

    [SerializeField]
    private float minX, maxX, minY, maxY;

    Vector3 moveVelocity;

    private float velocityLimit = 0.3f;
    private float walkDeaccelerationOnX;
    private float walkDeaccelerationOnY;
    public float walkDeacceleration = 3f;

    SpriteRenderer playerImage;
    PlayerController playerController;

    private void Start()
    {
        minX = background.transform.position.x - background.size.x / 2;
        maxX = background.transform.position.x + background.size.x / 2;

        minY = background.transform.position.y - background.size.y / 2;
        maxY = background.transform.position.y + background.size.y / 2;

        playerController = GetComponent<PlayerController>();

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


        var input = new Vector3(inputX, inputY).normalized * playerController._Speed;

        if (inputX < 0)
        {
            playerImage.flipX = false;
        }

        else if (inputX > 0)
        {
            playerImage.flipX = true;
        }
        if (inputY > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        //else
        //{
        //    transform.localScale *= -1;
        //}

        if (input.magnitude > 0)
        {
            playerController.ChangePlayerState(playerActionState.Walk);
            playerController.ChangeMove(inputY, inputX);
        }
        else
        {
            playerController.ChangePlayerState(playerActionState.Idle);
        }

        moveVelocity = new Vector3
            (Mathf.SmoothDamp(input.x, 0, ref walkDeaccelerationOnX, walkDeacceleration),
            Mathf.SmoothDamp(input.y, 0, ref walkDeaccelerationOnY, walkDeacceleration),
                                     0);

        transform.position += moveVelocity * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        //if (moveVelocity. < velocityLimit)
        //{
        //    rigid.velocity = Vector3.zero;
        //    rigid.angularVelocity = Vector3.zero;
        //}
    }
}
