using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    [Tooltip("Ajusta la velocidad aquí. Prueba con 100 o 150.")]
    public float speed = 100f;

    // NUEVO: Define hasta qué altura sube el texto antes de cerrarse
    [Tooltip("Posición Y donde se cierran los créditos. Calcula esto subiendo el texto manualmente.")]
    public float alturaFinal = 5000f; 
    
    private RectTransform miRectTransform;
    private Vector2 posicionInicial;
    private MainMenuManager menuManager; // NUEVO: Referencia al manager

    void Awake()
    {
        miRectTransform = GetComponent<RectTransform>();
        posicionInicial = miRectTransform.anchoredPosition;

        // NUEVO: Buscamos automáticamente el script del menú en la escena
        menuManager = FindObjectOfType<MainMenuManager>();
    }

    void OnEnable()
    {
        if (miRectTransform != null)
        {
            miRectTransform.anchoredPosition = posicionInicial;
        }
    }

    void Update()
    {
        if (miRectTransform != null)
        {
            // Mover hacia arriba
            miRectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;

            // NUEVO: Verificamos si ya llegamos al final
            if (miRectTransform.anchoredPosition.y > alturaFinal)
            {
                TerminarCreditos();
            }
        }
    }

    // NUEVO: Función para cerrar y volver al menú
    void TerminarCreditos()
    {
        // Llamamos a la función CloseCredits() que ya tienes en tu otro script
        if (menuManager != null)
        {
            menuManager.CloseCredits();
        }
        else
        {
            // Por si acaso no encuentra el manager, desactivamos el objeto manualmente
            gameObject.SetActive(false); 
            // Ojo: Si desactivas solo el texto, el fondo azul se quedará. 
            // Lo ideal es que funcione el menuManager.
            Debug.Log("Creditos terminados");
        }
    }
}