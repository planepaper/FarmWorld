using System;
using UnityEngine;

public class Tree : MonoBehaviour
{
    Action randomAction;
    int sortingOrder = 5;
    public CapsuleCollider2D col;
    private SpriteRenderer sprite;
    public void Init(float sizeX, float sizeY)
    {
        this.transform.localScale = new Vector3(sizeX,sizeY,1);
        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = sortingOrder;
    }

    public void SetRandomAction(Action action)
    {
        randomAction += action;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var distance = Vector2.Distance(collision.transform.position, this.transform.position);
        Debug.Log(distance);
        //if ((distance < col.bounds.size.x) || (distance < col.bounds.size.y))
        //{
        if (collision.CompareTag("Tree") == true && (collision.CompareTag("House") == true || collision.CompareTag("Fence") == true))
        {
            RandomnessPos();
        }

        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.sortingOrder = 5;
    }

    private void RandomnessPos()
    {
        randomAction.Invoke();
    }
}
