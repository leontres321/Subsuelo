using UnityEngine;

public class FantasmaController2 : MonoBehaviour
{
    public Transform pj;
    public GameObject boundary;
    public float Speed = 0.06f;

    Vector2 direccion;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    BoxCollider2D colisionadorPibe;
    Vector2 posInicial;

    float contador;
    float cambioAnimación;


    void Start()
    {
        cambioAnimación = 3f;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        colisionadorPibe = GetComponent<BoxCollider2D>();
        animator.Play("Apareciendo");
        posInicial = transform.position;
        contador = 0f;
        Event.singleton.RegresarPosicionInicial += VolverInicio;
    }

    void Update()
    {
        direccion = pj.position - transform.position;
        direccion.Normalize();
        FlipX();
        contador += Time.deltaTime;
        if (contador >= cambioAnimación)
        {
            animator.Play("ShoroPulento");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + (direccion * Speed)); 
    }

    private void FlipX()
    {
        sr.flipX = direccion.x > 0 ? true : false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PJ"))
        {
            pj.gameObject.GetComponent<PJController>().Hurt(1);
            Event.singleton.RegresarFantasmas();
        }
        if (collision.CompareTag("Sword"))
        {
            animator.Play("HaciendoLaMuricion");
            gameObject.SetActive(false);
        }
    }

    private void VolverInicio()
    {
        transform.position = posInicial;
        animator.Play("Normal");
        contador = 0f;
        gameObject.SetActive(false);
    }

    public void cambioAnimacionEvento()
    {
        contador = 0f;
        animator.Play("Normal");
    }
}
