using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    public float destroyTime = 2f; // Tiempo antes de destruir el sistema de partículas

    private void Start()
    {
        Destroy(gameObject, destroyTime); // Destruye el objeto después del tiempo especificado
    }
}
