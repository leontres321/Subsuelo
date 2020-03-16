using UnityEngine;

public class FantasmaController : MonoBehaviour
{
    public Transform pj;
    public GameObject boundary;
    public float Speed = 5f;

    Vector2 direccion;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    BoxCollider2D colisionadorPibe;
    Vector2 posInicial;

    bool _activo;
    float contador;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        colisionadorPibe = GetComponent<BoxCollider2D>();
        _activo = false;
        animator.Play("Apareciendo");
        posInicial = transform.position;
        contador = 0f;
        BolsaDeFantasmas.singleton.RegresarPosicionInicial += VolverInicio;
    }

    void Update()
    {
        // if active
        if (boundary.activeInHierarchy) _activo = true;

        if (_activo)
        {
            direccion = pj.position - transform.position;
            direccion.Normalize();
            FlipX();
            contador += Time.deltaTime;
        }
        
    }

    private void FixedUpdate()
    {
        if (_activo)
        {
            rb.MovePosition((Vector2)transform.position + (direccion * Speed)); 
        }
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
        }
        if (collision.CompareTag("Sword"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            animator.Play("HaciendoLaMuricion");
            _activo = false;
            Destroy(gameObject, 1f);
        }
    }

    private void VolverInicio()
    {
        transform.position = posInicial;
        _activo = false;
    }
}
