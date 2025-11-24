using UnityEngine;
using System.Collections;

public class Bomba : MonoBehaviour
{
    [Header("Configuración de la Explosión")]
    public float tiempoExplosion = 3.0f;
    public float radioExplosion = 2.0f;
    public int dañoCausado = 1;

    [Header("Persecución")]
    public float velocidadMovimiento = 3.0f;
    private Transform target;

    void Start()
    {
        // Encontrar al jugador (Etiqueta "Player")
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            target = jugador.transform;
        }

        StartCoroutine(TemporizadorExplosion());
    }

    // Usamos FixedUpdate para la lógica de movimiento (funciona con Is Kinematic ON)
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direccion = (target.position - transform.position).normalized;
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.MovePosition(transform.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);

                // Rotación simple para animación visual
                transform.Rotate(Vector3.up * (velocidadMovimiento * 50) * Time.fixedDeltaTime);
            }
        }
    }

    IEnumerator TemporizadorExplosion()
    {
        yield return new WaitForSeconds(tiempoExplosion);
        Explode();
    }

    void Explode()
    {
        // 1. Detección de colisión (Physics.OverlapSphere)
        Collider[] objetosChocados = Physics.OverlapSphere(transform.position, radioExplosion);

        foreach (Collider collider in objetosChocados)
        {
            if (collider.CompareTag("Player")) // Busca la etiqueta "Player"
            {
                VidaManager vidaJugador = collider.GetComponent<VidaManager>();

                if (vidaJugador != null)
                {
                    vidaJugador.RecibirDaño(dañoCausado);
                }
            }
        }

        // 2. Eliminar la bomba
        Destroy(gameObject);
    }
}