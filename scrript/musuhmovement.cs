using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuhmovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Transform leftPoint;
    [SerializeField] Transform rightPoint;

    Rigidbody2D myRigidbody;
    SpriteRenderer mySpriteRenderer;
    bool isFacingLeft = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (isFacingLeft)
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, myRigidbody.velocity.y);

            if (transform.position.x < leftPoint.position.x)
            {
                Flip();
            }
        }
        else
        {
            myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

            if (transform.position.x > rightPoint.position.x)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        mySpriteRenderer.flipX = !mySpriteRenderer.flipX;
    }
}
