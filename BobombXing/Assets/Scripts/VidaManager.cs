using UnityEngine;
using UnityEngine.UI;

public class VidasManager : MonoBehaviour
{
    public int vidas = 3;
    public Image[] corazones; // Arreglo con tus tres imágenes
    public Sprite corazonLleno;
    public Sprite corazonVacio;

    void Update()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].sprite = i < vidas ? corazonLleno : corazonVacio;
        }

        // 🔹 Esto es solo para probar: presiona Espacio y pierde una vida
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerderVida();
        }
    }

    public void PerderVida()
    {
        if (vidas > 0)
            vidas--;
    }
}
