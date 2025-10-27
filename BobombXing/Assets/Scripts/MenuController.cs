using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuPrincipal; // Panel del men� (fondo + t�tulo + bot�n)

    // Funci�n para ocultar el men�
    public void IniciarJuego()
    {
        menuPrincipal.SetActive(false); // Oculta todo el men�
    }
}
