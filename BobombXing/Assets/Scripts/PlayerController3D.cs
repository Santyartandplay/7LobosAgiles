using UnityEngine;

public class MarioMovimiento3D : MonoBehaviour
{
    public float velocidad = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.UpArrow)) vertical = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) vertical = -1f;
        if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) horizontal = 1f;

        Vector3 direccion = new Vector3(horizontal, 0, vertical).normalized;

        // Se mueve si hay dirección
        if (direccion.magnitude > 0)
        {
            Vector3 movimiento = direccion * velocidad * Time.deltaTime;
            rb.MovePosition(transform.position + movimiento);

            // Hace que gire en dirección al movimiento
            transform.rotation = Quaternion.LookRotation(direccion);
        }
    }
}
