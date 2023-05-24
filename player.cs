using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Animator anim;
    public float darah;
    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();   
    }
    void Die()
    {
        anim.SetTrigger("die");
        Invoke("DestroyObject", 0.8f);
        
    }
    void DestroyObject(){
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      public void TakeDamage(float damage){
        darah -= damage;
        if (darah <= 0)
        {
            Die();
        }
     }

}
