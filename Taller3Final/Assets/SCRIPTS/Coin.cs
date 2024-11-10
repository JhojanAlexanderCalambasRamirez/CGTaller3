using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public static int coinCount = 0; // Contador de monedas
    public TextMeshProUGUI contadorText; // Referencia al TextMeshProUGUI
    public GameObject particulasPrefab; // Partícula que se mostrará al recoger la moneda

    private void Start()
    {
        UpdateCoinCounter(); // Actualizar el contador al inicio
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            coinCount++; // Incrementar el contador
            UpdateCoinCounter(); // Actualizar el texto del contador

            // Instanciar la partícula en la posición de la moneda
            if (particulasPrefab != null)
            {
                Instantiate(particulasPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject); // Destruir la moneda
        }
    }

    private void UpdateCoinCounter()
    {
        if (contadorText != null)
        {
            contadorText.text = coinCount.ToString(); // Solo muestra el número de monedas
        }
        else
        {
            Debug.LogWarning("El contadorText no está asignado en el inspector.");
        }
    }
}
