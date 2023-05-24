using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private MovementController movementController;
    private JumpController jumpController;
    private Animator animator;
    private Rigidbody2D rb;
    public float damage = 1f;


    void OnCollisionEnter2D(Collision2D target)
    {
        // Cek jika peluru mengenai musuh
        if (target.gameObject.tag == "musuh")
        {
            // Panggil fungsi TakeDamage pada script musuh
            target.gameObject.GetComponent<musuh>().TakeDamage(damage);
        }
    }

    void Start()
    {
        // Inisialisasi class-class yang digunakan
        movementController = new MovementController(5f);
        jumpController = new JumpController(8f);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Update animasi
        animator.SetBool("lari", movementController.IsMoving());

        // Update gerakan
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        movementController.Move(transform, input);

        // Update rotasi
        if (input.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (input.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // Update lompatan
        if (Input.GetButtonDown("Jump") && jumpController.CanJump())
        {
            jumpController.Jump(rb);
            animator.SetBool("lompat", true);
        }
        else
        {
            animator.SetBool("lompat", false);
        }
    }
}

// Class untuk mengatur gerakan
public class MovementController
{
    private float speed;

    public MovementController(float speed)
    {
        this.speed = speed;
    }

    public void Move(Transform transform, Vector2 input)
    {
        Vector2 position = transform.position;
        position += input.normalized * speed * Time.deltaTime;
        transform.position = position;
    }

    public bool IsMoving()
    {
        return Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0;
    }
}

// Class untuk mengatur lompatan
public class JumpController
{
    private float jumpForce;
    private float jumpTimer;
   

    public JumpController(float jumpForce)
    {
        this.jumpForce = jumpForce;
    }

    public void Jump(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpTimer = Time.time + 0.2f;
    }

    public bool CanJump()
    {
        return Time.time >= jumpTimer;
    }
    
}
