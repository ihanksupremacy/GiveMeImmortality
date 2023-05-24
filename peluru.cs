using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peluru : MonoBehaviour
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
    
    void OnCollisionEnter2D(Collision2D target)
    {
        // Cek jika peluru mengenai musuh
        if (target.gameObject.tag == "musuh")
        {
            // Panggil fungsi TakeDamage pada script musuh
            target.gameObject.GetComponent<musuh>().TakeDamage(damage);

            // Hancurkan peluru
            Destroy(gameObject);
        }
        if (target.gameObject.tag == "musuhmale")
        {
            // Panggil fungsi TakeDamage pada script musuh
            target.gameObject.GetComponent<musuhmale>().TakeDamage(damage);

            // Hancurkan peluru
            Destroy(gameObject);
        }
    }
}
