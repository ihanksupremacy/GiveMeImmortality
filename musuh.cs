using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuh : MonoBehaviour
{
    public float musuhHp;
    public Animator anim;
    public float damage = 1f;
    
 void Die()
    {
        anim.SetBool("mati", true);
        Invoke("DestroyObject", 0.8f);
        
    }
    void DestroyObject(){
        Destroy(gameObject);
    }
    // Fungsi untuk mengurangi HP musuh
    public void TakeDamage(float damage)
    {
        musuhHp -= damage;
        if (musuhHp <= 0)
        {
            Die();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.otherCollider.CompareTag("DamageDealer"))
        {
            // collider yang memberikan kerusakan bersentuhan dengan pemain
            collision.gameObject.GetComponent<player>().TakeDamage(damage);
        }
        else if (collision.collider.CompareTag("pijak") && collision.otherCollider.CompareTag("DamageReceiver"))
        {
            // collider yang menerima kerusakan dari pemain bersentuhan dengan pemain
            TakeDamage(damage);
        }

    }
}
