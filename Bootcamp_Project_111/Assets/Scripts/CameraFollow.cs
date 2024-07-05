using UnityEngine;

namespace MarwanZaky
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target; // Takip edilecek hedef (karakter)
        public float smoothSpeed = 0.125f; // Yumu�ak ge�i� h�z�
        public Vector3 offset = new Vector3(0f, 2f, -5f); // Kamera ile hedef aras�ndaki mesafe ve y�kseklik ayar�

        private float rotationSmoothTime = 0.1f; // Yumu�ak d�n�� zaman�
        private Vector3 velocity = Vector3.zero; // D�n�� h�z� i�in kullan�lacak de�i�ken

        void LateUpdate()
        {
            if (target != null)
            {
                // Kamera hedefin (karakterin) �st�nde ve arkas�nda kalacak �ekilde pozisyonunu ayarla
                Vector3 desiredPosition = target.position + offset.y * target.up - offset.z * target.forward;
                transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

                // Kamera d�n���n� hedefin (karakterin) d�n���ne g�re ayarla
                Quaternion targetRotation = Quaternion.Euler(30f, target.eulerAngles.y, 0f);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothTime);
            }
        }
    }
}