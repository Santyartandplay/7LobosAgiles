using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaManager : MonoBehaviour
{
    public int vidaActual = 3;
    public GameObject[] corazonesVisuales;

    public void RecibirDaño(int daño)
    {
        vidaActual -= daño;

        // Si tienes corazones asignados, oculta uno
        if (corazonesVisuales != null && vidaActual >= 0 && vidaActual < corazonesVisuales.Length)
        {
            corazonesVisuales[vidaActual].SetActive(false);
        }

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}