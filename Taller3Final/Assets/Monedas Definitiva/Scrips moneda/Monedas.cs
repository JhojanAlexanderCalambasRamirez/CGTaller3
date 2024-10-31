using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    public Stats _stats;

  private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            _stats.monedas++;
            Destroy(gameObject);
        }
    }
}
