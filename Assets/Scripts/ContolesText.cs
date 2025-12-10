using UnityEngine;
using TMPro; // Necesario para TextMeshPro
using System.Collections;

public class ContolesText : MonoBehaviour
{
    public float esperarSegundos = 3f;
    public float velocidadDesvanecer = 1f;
    public TextMeshProUGUI miTexto;

    void Start()
    {
        if (miTexto == null) miTexto = GetComponent<TextMeshProUGUI>();

        // Iniciamos la rutina
        StartCoroutine(RutinaDesaparecer());
    }

    IEnumerator RutinaDesaparecer()
    {

        yield return new WaitForSeconds(esperarSegundos);

        miTexto.CrossFadeAlpha(0.0f, velocidadDesvanecer, false);
    }
}
