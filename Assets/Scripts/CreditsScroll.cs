using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    public float alturaFinal = 5000f; 
    // Velocidad de desplazamiento de los créditos (unidades por segundo)
    public float speed = 50f;

    private RectTransform miRectTransform;
    private Vector2 posicionInicial;
    private MainMenuManager menuManager;

    void Awake()
    {
        miRectTransform = GetComponent<RectTransform>();
        posicionInicial = miRectTransform.anchoredPosition;

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
            miRectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;
            if (miRectTransform.anchoredPosition.y > alturaFinal)
            {
                TerminarCreditos();
            }
        }
    }

    void TerminarCreditos()
    {
        if (menuManager != null)
        {
            menuManager.CloseCredits();
        }
        else
        {
            gameObject.SetActive(false); 
            Debug.Log("Creditos terminados");
        }
    }
}