using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coinCount = 0;
    public GameObject particulasPrefab; // Prefab del sistema de partículas para la moneda

    // Start is called before the first frame update
    void Start()
    {
        Coin.coinCount += 1;
        Debug.Log("Empieza el juego con " + Coin.coinCount + " monedas");
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            // Instancia el sistema de partículas en la posición de la moneda
            Instantiate(particulasPrefab, transform.position, Quaternion.identity);

            Coin.coinCount--;
            Debug.Log("Moneda recogida, quedan " + Coin.coinCount + " monedas");

            if (Coin.coinCount == 0)
            {
                Debug.Log("Juego Terminado");
            }

            // Destruye la moneda
            Destroy(gameObject);
        }
    }
}
