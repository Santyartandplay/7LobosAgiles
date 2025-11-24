using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [Header("Configuración del Spawning")]
    public GameObject prefabBomba;
    public Transform[] puntosSpawn;
    public float intervaloSpawn = 3f;
    public float tiempoInicio = 1f;

    void Start()
    {
        if (puntosSpawn == null || puntosSpawn.Length == 0)
        {
            Debug.LogError("¡El Spawner no tiene puntos de spawn asignados! Asigna los 4 puntos en el Inspector.");
            return;
        }
        InvokeRepeating("GenerarBomba", tiempoInicio, intervaloSpawn);
    }

    void GenerarBomba()
    {
        // 1. Elegir un punto de spawn ALEATORIO (funciona si Size es 4)
        Transform puntoSpawn = puntosSpawn[Random.Range(0, puntosSpawn.Length)];

        // 2. Instanciar la bomba
        Instantiate(prefabBomba, puntoSpawn.position, puntoSpawn.rotation);
    }
}