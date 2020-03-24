using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.SceneManagement;

public class FinalBoss : MonoBehaviour
{
    public GameObject PJ;
    public Light2D luz;
    public ShakeCoroutine shakeYourBooty;

    int vida;
    AudioSource dano;
    Animator animator;
    AudioSource pewpew;

    //Acciones
    bool activo;

    float contador;
    float tiempoAccion;

    int ataqueActivo;

    float tiempoInvulnerabilidad;
    float contadorVulnerabilidad;

    // Start is called before the first frame update
    void Start()
    {
        vida = 10; //todo:cambiar
        dano = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        activo = false;
        tiempoAccion = 1f;
        contador = 0f;
        contadorVulnerabilidad = 1f;
        tiempoInvulnerabilidad = 0.6f;
        luz.gameObject.SetActive(true);
        luz.intensity = .6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            contador += Time.deltaTime;
            contadorVulnerabilidad += Time.deltaTime;
            if (contador > tiempoAccion)
            {
                switch (ataqueActivo)
                {
                    case 1: // Rayo sobre pj
                        break;
                    case 2: // 4 rayos
                        break;
                    case 3: // rayos horizontales
                        break;
                    case 4: // rayos diagonales
                        break;
                    case 5: 
                        break;
                }
                contador = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword") && contadorVulnerabilidad >= tiempoInvulnerabilidad)
        {
            contadorVulnerabilidad = 0f;
            dano?.Play();
            Hurt();
        }
    }

    private void Hurt()
    {
        vida--;
        //barreras?
        if (vida > 3)
        {
            animator.Play("Dano");
        }
        else if (vida > 0)
        {
            animator.Play("GraveDano");
        }
        else //Vida 0
        {
            animator.Play("Moricir");
            PJ.GetComponent<PJController>().Wait(5);
            Destroy(gameObject, 5f); //todo:revisar aaaaaaah
            StartCoroutine(shakeYourBooty.ShakeFinal());
        }
    }

    public void activar()
    {
        activo = true;
    }

    public void cambiarIdle()
    {
        animator.Play("Idle");
    }

    public void cambiarGrave()
    {
        animator.Play("Grave");
    }

    public void Moricir()
    {
        SceneManager.LoadScene(0);
    }
}
