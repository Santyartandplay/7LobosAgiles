using UnityEngine;
public class MarioMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento (ajusta en Inspector)
    public float rotationSpeed = 100f; // Velocidad de rotación (opcional, ajusta en Inspector)
    public Animator animator; // Asigna el Animator en Inspector (opcional)
    void Update()
    {
        // Movimiento hacia adelante (eje Z en 3D; cambia a Vector3.right para 2D)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // Rotación opcional (para simular giro mientras camina)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        // Activar animación de caminar si hay Animator
        if (animator != null)
        {
            animator.SetBool("IsMoving", true); // Asegúrate de tener un parámetro Bool "IsMoving" en el Animator
        }
    }
}
