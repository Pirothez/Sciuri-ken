using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 firstPos, lastPos, direction;
    public float swipeForce = 8.5f;

    bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        //isMoving is to avoid that the player can touch the flower multiple times
        if (Input.touchCount > 0 && !isMoving)
        {
            //there is at least 1 touch
            Touch touch = Input.touches[0];

            //TouchPhase.Began, TouchPhase.Moved, TouchPhase.Ended
            switch (touch.phase)
            {
                case (TouchPhase.Began):
                    firstPos = new Vector2(touch.position.x, touch.position.y);
                    firstPos = Camera.main.ScreenToWorldPoint(firstPos);
                    break;
                case (TouchPhase.Ended):
                    lastPos = new Vector2(touch.position.x, touch.position.y);
                    lastPos = Camera.main.ScreenToWorldPoint(lastPos);
                    direction = (lastPos - firstPos).normalized;
                    rb.isKinematic = false;
                    rb.AddForce(direction * swipeForce, ForceMode2D.Impulse);
                    isMoving = true;
                    //  anim.SetTrigger("IsMoving");
                    break;
                default:
                    break;
            }
        }
    }
}