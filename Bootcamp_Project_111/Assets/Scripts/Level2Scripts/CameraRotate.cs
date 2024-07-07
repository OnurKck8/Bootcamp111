using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform targetTransform; // Kameran�n gidece�i hedef Transform
    public float transitionSpeed = 1f; // Kameran�n hareket ve rotasyon h�z�

    private bool moveToTarget = false;

    void Update()
    {
        if (moveToTarget)
        {
            // Pozisyonu yumu�ak bir �ekilde de�i�tirme
            transform.position = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * transitionSpeed);
            // Rotasyonu yumu�ak bir �ekilde de�i�tirme
            Quaternion targetQuaternion = Quaternion.Euler(targetTransform.rotation.eulerAngles);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, Time.deltaTime * transitionSpeed);

            // Hedef pozisyon ve rotasyona ula��ld���nda hareketi durdur
            if (Vector3.Distance(transform.position, targetTransform.position) < 0.01f && Quaternion.Angle(transform.rotation, targetQuaternion) < 0.1f)
            {
                moveToTarget = false;
            }
        }
    }

    public void MoveToTarget()
    {
        moveToTarget = true;
    }
}
