using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuhmale : MonoBehaviour
{
    public float musuhHp;
    public Animator anim;
    public float damage = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.otherCollider.CompareTag("DamageDealer"))
        {
            // collider yang memberikan kerusakan bersentuhan dengan pemain
            collision.gameObject.GetComponent<player>().TakeDamage(damage);
        }
        else if (collision.gameObject.CompareTag("Player") && collision.otherCollider.CompareTag("DamageReceiver"))
        {
            // collider yang menerima kerusakan dari pemain bersentuhan dengan pemain
            TakeDamage(damage);
        }

    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        musuhHp -= damage;
        if (musuhHp <= 0)
        {
            Die();
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

}
