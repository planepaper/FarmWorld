using System;
using Unity.VisualScripting;
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
        randomAction = action;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var distance = Vector2.Distance(collision.transform.position, this.transform.position);
        Debug.Log(distance);
        if ((distance < col.bounds.size.x) || (distance < col.bounds.size.y))
        {
            RandomnessPos();
        }
        if(collision.TryGetComponent(out SpriteRenderer sprite))
        {
            if((distance < col.bounds.size.y * 0.2f) && collision.transform.position.y < transform.position.y)
            {
                this.sprite.sortingOrder = sprite.sortingOrder -1;
            }
            else if ((distance < col.bounds.size.y * 0.2f) && collision.transform.position.y < transform.position.y)
            {
                this.sprite.sortingOrder = sprite.sortingOrder +1;
            }
        }
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
