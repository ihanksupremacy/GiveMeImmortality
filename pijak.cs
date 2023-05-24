using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pijak : MonoBehaviour
{
    public float damage = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D target)
    {
        // Cek jika peluru mengenai musuh
        if (target.gameObject.tag == "musuh")
        {
            // Panggil fungsi TakeDamage pada script musuh
            target.gameObject.GetComponent<musuh>().TakeDamage(damage);

        }
    }
}
