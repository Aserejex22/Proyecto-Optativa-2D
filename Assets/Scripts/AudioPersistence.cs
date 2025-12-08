using UnityEngine;

public class AudioPersistence : MonoBehaviour
{
    private void Awake()
    {
        // Busca si ya existe un objeto con este componente.
        // Si ya existe, destruye esta copia para evitar duplicados.
        int count = FindObjectsOfType<AudioPersistence>().Length;
        if (count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            // Mantiene este objeto vivo al cargar una nueva escena.
            DontDestroyOnLoad(gameObject);
        }
    }
}