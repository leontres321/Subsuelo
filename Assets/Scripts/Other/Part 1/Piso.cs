using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : MonoBehaviour
{
    public ShakeCoroutine cameraShake;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PJ"))
        {
            StartCoroutine(cameraShake.Shake(2f, .4f));
            collision.gameObject.GetComponent<PJController>().Wait(3);
            Destroy(gameObject, 3);
        }
    }

}
