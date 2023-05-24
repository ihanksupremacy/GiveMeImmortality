using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuh2 : MonoBehaviour
{


    private Animator anim;
    private bool bisaAtt = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("EnemyAttack", 1f, 3f);
    }

    void EnemyAttack()
    {
        if (bisaAtt)
        {
            anim.SetBool("att", true);
            bisaAtt = false;
            Invoke("SetBisaAtt", 1f);
            Invoke("SetBisaLari", 0.5f);
            // lakukan serangan ke pemain di sini
        }
    }

    void SetBisaAtt()
    {
        anim.SetBool("att", false);
        bisaAtt = true;
    }




}
