using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tembakan : MonoBehaviour
{
    public GameObject peluru;
    public Transform pointTembak;
    private bool bisaMenembak = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && bisaMenembak)
        {
            //membuat objek peluru dan menembakkannya
            GameObject peluruS = Instantiate(peluru, pointTembak.position, pointTembak.rotation);
            peluruS.GetComponent<Rigidbody2D>().velocity = transform.right * 25;
            Destroy(peluruS, 2f);

            //mengatur status bisaMenembak menjadi false untuk menunggu 1 detik
            bisaMenembak = false;
            Invoke("SetBisaMenembak", 1f);
        }
    }

    void SetBisaMenembak()
    {
        bisaMenembak = true;
    }


}
