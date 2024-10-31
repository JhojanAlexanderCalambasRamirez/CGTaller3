//Alexander Calambas - 2190555
//Juan Manuel Santos - 2215928
//Juan David Rios - 2225674


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase AudioManager:
/// Esta clase gestiona la reproducción de efectos de sonido cuando un objeto con la etiqueta "Player"
/// entra en contacto con el trigger asociado a este objeto. Utiliza un componente AudioSource para
/// manejar el audio.
/// </summary>
public class AudioManager : MonoBehaviour
{
    // Referencia al componente AudioSource para reproducir el sonido
    private AudioSource audioSource;

    /// <summary>
    /// Método Start:
    /// Inicializa la referencia al componente AudioSource del objeto. Se llama al inicio de la ejecución
    /// del script.
    /// </summary>
    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtiene el componente AudioSource del objeto
    }

    /// <summary>
    /// Método OnTriggerEnter2D:
    /// Se ejecuta cuando otro objeto con un Collider2D entra en el trigger asociado a este objeto.
    /// Si el objeto que entra tiene la etiqueta "Player", se reproduce el sonido.
    /// </summary>
    /// <param name="other">El Collider2D del objeto que ha entrado en el trigger.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que entra tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            audioSource.Play(); // Reproducir el sonido asociado al AudioSource
        }
    }
}
