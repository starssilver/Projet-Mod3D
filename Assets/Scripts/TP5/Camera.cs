using UnityEngine;



public class CameraFollow : MonoBehaviour

{

    public Transform target;     // Le joueur à suivre

    public float height = 10f;   // Hauteur de la caméra au-dessus du joueur

    public float smoothSpeed = 5f; // Vitesse de suivi



    void LateUpdate()

    {

        if (target == null) return;



        // Position souhaitée : juste au-dessus du joueur

        Vector3 desiredPosition = target.position + Vector3.up * height;



        // Interpolation pour un mouvement fluide

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);



        transform.position = smoothedPosition;



        // Toujours regarder le joueur

        transform.rotation = Quaternion.Euler(90f, 0f, 0f); // Vue du dessus

    }

}