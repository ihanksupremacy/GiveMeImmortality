using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuhmovementvertika : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Transform topPoint;
    [SerializeField] Transform bottomPoint;

    Rigidbody2D myRigidbody;
    SpriteRenderer mySpriteRenderer;
    bool isFacingUp = true;

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
        if (isFacingUp)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, moveSpeed);

            if (transform.position.y > topPoint.position.y)
            {
                Flip();
            }
        }
        else
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -moveSpeed);

            if (transform.position.y < bottomPoint.position.y)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        isFacingUp = !isFacingUp;
        mySpriteRenderer.flipY = !mySpriteRenderer.flipY;
    }
}
