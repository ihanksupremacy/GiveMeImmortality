using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float ms;
    public float jf;
    private Rigidbody2D rb;
    Vector3 jalan;
    public Animator anime;
    private bool inAir = false;
    private float jumpTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        jalan.x = Input.GetAxisRaw("Horizontal");
        transform.position += jalan * ms * Time.deltaTime;

        if (jalan == Vector3.zero) {
            anime.SetBool("lari", true);
        } else {
            anime.SetBool("lari", false);
        }

        if (jalan == Vector3.left) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else if (jalan == Vector3.right) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if(Input.GetButtonDown("Jump") && !inAir){
            rb.AddForce(new Vector2 (0,jf));
            anime.SetBool("lompat", true);
            inAir = true;
            jumpTime = Time.time;
        }
        else{
            anime.SetBool("lompat", false);
            if (inAir && Time.time - jumpTime > 0.5f) {
                inAir = false;
            }
        }
    }
}

