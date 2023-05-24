using UnityEngine;

namespace ClearSky
{
    public class SimplePlayerController : MonoBehaviour
    {
        public float movePower = 10f;
        public float jumpPower = 15f; 

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        bool isLompat = false;
        private bool alive = true;
        private bool bisaAtt = true;
        private bool bisaLari = true;
        


     
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                Hurt();
                Die();
                Attack();
                Jump();
                Run();

            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }


        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);


            if (Input.GetAxisRaw("Horizontal") < 0 && bisaLari)
            {
                direction = -1;
                moveVelocity = Vector3.left;

                transform.rotation = Quaternion.Euler(0, 180, 0);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0 && bisaLari)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.rotation = Quaternion.Euler(0, 0, 0);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0 )
            && !anim.GetBool("isJump"))
            {
                isLompat = true;
                anim.SetBool("isJump", true);
            }
            if (!isLompat)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isLompat = false;
        }
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Q) && bisaAtt)
            {
                anim.SetTrigger("attack");
                bisaAtt=false;
                Invoke("SetBisaAtt",1f);
                bisaLari=false;
                Invoke("SetBisaLari",0.5f);
            }
        }
        void SetBisaAtt(){
            bisaAtt = true;
        }
        void SetBisaLari(){
            bisaLari = true;
        }

        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {

            {
            
            }
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                anim.SetTrigger("idle");
                alive = true;
            }
        }
      
    }
}