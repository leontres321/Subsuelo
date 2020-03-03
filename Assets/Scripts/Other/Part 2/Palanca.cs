using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    public Sprite palancaActivada;
    public GameObject control;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword"))
        {
            GetComponent<SpriteRenderer>().sprite = palancaActivada;
            control.SetActive(false);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
