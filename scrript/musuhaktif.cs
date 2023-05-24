using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuhaktif : MonoBehaviour
{
     private Camera cam;

    private void Start()
    {
        // Mendapatkan komponen kamera
        cam = Camera.main;
    }

    private void Update()
    {
        // Mencari tampilan layar dari objek musuh
        Vector3 screenPos = cam.WorldToScreenPoint(transform.position);

        // Jika objek musuh berada di dalam view kamera, aktifkan layer "Enemy"
        if (screenPos.x > 0 && screenPos.x < Screen.width && screenPos.y > 0 && screenPos.y < Screen.height && screenPos.z > 0)
        {
            cam.cullingMask |= (1 << LayerMask.NameToLayer("Enemy"));
        }
        // Jika objek musuh berada di luar view kamera, matikan layer "Enemy"
        else
        {
            cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Enemy"));
        }
    }
}
