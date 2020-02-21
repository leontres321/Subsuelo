using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy_1"))
        {
            var clase = collision.gameObject.GetComponent<JellyClass>();
            clase.sm.pushBack();
        }
    }
}
