using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    public float destroyTime = 2f; // Tiempo antes de destruir el sistema de part�culas

    private void Start()
    {
        Destroy(gameObject, destroyTime); // Destruye el objeto despu�s del tiempo especificado
    }
}
