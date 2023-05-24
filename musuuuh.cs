using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuuuh : MonoBehaviour
{
    public GameObject peluru;
    public Transform pointTembak;
    private bool bisaAtt = true;
    public float damage = 1f; // damage yang diberikan pada musuh

    void Start() {
        InvokeRepeating("EnemyAttack", 1.5f, 3f);
    }

    void EnemyAttack()
    {
        if (bisaAtt)
        {
            //membuat objek peluru dan menembakkannya
            GameObject peluruS = Instantiate(peluru, pointTembak.position, pointTembak.rotation);
            peluruS.GetComponent<Rigidbody2D>().velocity = transform.right * -40;
            Destroy(peluruS, 0.5f);

            //mengatur status bisaMenembak menjadi false untuk menunggu 1 detik
            bisaAtt = false;
            Invoke("SetBisaAtt", 1f);

        }
    }

    void SetBisaAtt()
    {
        bisaAtt = true;
    }
}
