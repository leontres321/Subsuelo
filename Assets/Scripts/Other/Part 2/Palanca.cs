using UnityEngine;

public class Palanca : MonoBehaviour
{
    public Sprite palancaActivada;
    public GameObject control;
    public ShakeCoroutine pantalla;
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
            StartCoroutine(pantalla.Shake(1.9f, 0.25f));
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
