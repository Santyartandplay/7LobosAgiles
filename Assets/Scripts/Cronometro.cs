using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public TextMeshProUGUI tiempoActualText;
    public TextMeshProUGUI mejorTiempoText;

    private float tiempoActual = 0f;
    private float mejorTiempo = 0f;
    private bool enMarcha = true;

    void Start()
    {
        // Cargar récord anterior si existe
        mejorTiempo = PlayerPrefs.GetFloat("MejorTiempo", 0f);
        ActualizarTextoMejorTiempo();
    }

    void Update()
    {
        if (enMarcha)
        {
            tiempoActual += Time.deltaTime;
            ActualizarTextoTiempoActual();
        }
    }

    void ActualizarTextoTiempoActual()
    {
        int minutos = Mathf.FloorToInt(tiempoActual / 60);
        float segundos = tiempoActual % 60;
        tiempoActualText.text = $"{minutos:00}:{segundos:00.00}";
    }

    void ActualizarTextoMejorTiempo()
    {
        int minutos = Mathf.FloorToInt(mejorTiempo / 60);
        float segundos = mejorTiempo % 60;
        mejorTiempoText.text = $"Mejor: {minutos:00}:{segundos:00.00}";
    }

    public void DetenerCronometro()
    {
        enMarcha = false;

        // Guardar récord si este tiempo es mejor
        if (mejorTiempo == 0f || tiempoActual < mejorTiempo)
        {
            mejorTiempo = tiempoActual;
            PlayerPrefs.SetFloat("MejorTiempo", mejorTiempo);
            PlayerPrefs.Save();
            ActualizarTextoMejorTiempo();
        }
    }

    public void ReiniciarCronometro()
    {
        tiempoActual = 0f;
        enMarcha = true;
    }
}
