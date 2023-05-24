using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musuh : MonoBehaviour
{
    public float musuhHp;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        musuhHp -= damage;
        if (musuhHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetBool("mati", true);
        Invoke("DestroyObject", 0.8f);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
