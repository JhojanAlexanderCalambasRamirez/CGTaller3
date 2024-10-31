using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coinCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        Coin.coinCount = Coin.coinCount + 1;
        Debug.Log("Empieza el juego" + Coin.coinCount + "monedas");

        
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player") == true)
        {

        }

        Coin.coinCount --;
        Debug.Log("Moneda recogida" + Coin.coinCount + "monedas");
    
        if(Coin.coinCount == 0)
        {
            Debug.Log("Juego Terminado");
        }

        Destroy(gameObject);

    }


}
