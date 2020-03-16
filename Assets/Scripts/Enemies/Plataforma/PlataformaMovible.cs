using UnityEngine;

public class PlataformaMovible : MonoBehaviour
{
    public bool subiendo;
    public float tiempoRecorrido;
    public float delay;
    public float velocidad;

    private float time;
    private float timeDelay;
    private int direccion;
    private Rigidbody2D rb;
    void Start()
    {
        time = 0f;
        timeDelay = 0f;
        rb = GetComponent<Rigidbody2D>();
        direccion = subiendo ? 1 : -1;

    }

    //Esto creo que es lo único de verdad bonito que tiene el juego y por el solo hecho de que 
    //es modificable por el editor
    void Update()
    {
        if (time >= tiempoRecorrido)
        {
            if (timeDelay >= delay)
            {
                time = 0f;
                timeDelay = 0f;
                direccion *= -1;
            }
            else
            {
                timeDelay += Time.deltaTime;
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            time += Time.deltaTime;
            rb.velocity = Vector2.up * velocidad * direccion;
        }
    }
}
