using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public Transform target; // objek yang akan diikuti oleh kamera
    public float smoothSpeed = 0.3f; // kehalusan atau smoothness pergerakan kamera
    public Vector3 offset; // jarak relatif antara objek target dan kamera

    private void FixedUpdate()
    {
        // menghitung posisi target yang diikuti kamera
        Vector3 desiredPosition = target.position + offset;

        // menghitung posisi kamera dengan smoothness tertentu
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // mengatur posisi kamera
        transform.position = smoothedPosition;
    }
}
