using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuPrincipal; // Panel del menú (fondo + título + botón)

    // Función para ocultar el menú
    public void IniciarJuego()
    {
        menuPrincipal.SetActive(false); // Oculta todo el menú
    }
   
}
