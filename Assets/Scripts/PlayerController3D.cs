using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    private CharacterController controller;

    [Header("Movimiento")]
    public float velocidadMovimiento = 50f;
    public float velocidadRotacion = 300f;

    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. Obtener Input
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoZ = Input.GetAxis("Vertical");

        // SOLUCIÓN DEFINITIVA: INVERTIR el eje Z (Adelante/Atrás)
        Vector3 movimiento = new Vector3(movimientoX, 0, movimientoZ * -1);

        if (movimiento.magnitude > 1f)
        {
            movimiento.Normalize();
        }

        // 2. MOVER EL PERSONAJE
        controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);

        // 3. ROTACIÓN (Asegura que Mario mire en la dirección del movimiento invertido)
        if (movimiento.magnitude > 0.1f)
        {
            Quaternion rotacionDeseada = Quaternion.LookRotation(movimiento);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime);
        }

        // 4. ANIMACIÓN
        if (animator != null)
        {
            animator.SetFloat("Velocidad", movimiento.magnitude * velocidadMovimiento);
        }
    }
}