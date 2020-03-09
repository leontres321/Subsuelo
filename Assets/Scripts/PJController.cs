using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PJController : MonoBehaviour
{
    public StateMachine sm;
    public Animator anim;
    public bool end_jump;
    public bool caer;
    public Inventory inventario;

    public Rigidbody2D rb;

    //corazones van de izq a derecha
    public GameObject uno;
    public GameObject dos;
    public GameObject tres;
    public GameObject uno_medio;
    public GameObject dos_medio;
    public GameObject tres_medio;
    public GameObject uno_vacio;
    public GameObject dos_vacio;
    public GameObject tres_vacio;

    static int vida;
    bool _activo;
    float _timer;
    int _tiempo_necesario;

    public float time_falling;
    readonly float TIME_FALLING = 0.05f;

    public bool _yaColisiono;

    Vector2 _lastCheckPoint;

    public ShakeCoroutine cameraShake;

    public AudioSource pisada_1;
    public AudioSource pisada_2;
    public AudioSource caida;
    public AudioSource espada;
    public AudioClip espadaVithe;

    Dictionary<string, AudioSource> sonidos;

    void Start(){
        end_jump = false;
        caer = true;
        _activo = true;
        _timer = 0f;
        if (SceneManager.GetActiveScene().buildIndex == 1) //La primera escena te da toda la vida el resto mantiene la vida antigua
        {
            vida = 6;
        }
        else
        {
            ChangeHearths(vida);
        }

        sm = new StateMachine(this, anim);
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        rb = GetComponent<Rigidbody2D>();
        inventario = new Inventory();
        time_falling = 0f;
        sonidos = new Dictionary<string, AudioSource>();

        sonidos.Add("pisada_1",pisada_1);
        sonidos.Add("pisada_2", pisada_2);
        sonidos.Add("espada", espada);
        sonidos.Add("caida", caida);


        _yaColisiono = false;
    }

    void Update(){
        if (_activo)
        {
            sm.ExecuteStateUpdate();
            if (Input.GetButton("Exit"))
            {
                Application.Quit();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Hurt(1);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                Heal(1);
            }
        }
        else
        {
            //Al personaje se le dijo wait
            _timer += Time.deltaTime;
            if (_timer >= _tiempo_necesario)
            {
                _activo = true;
                _timer = 0f;
            }
        }
    }

    void FixedUpdate(){
        if (end_jump)
        {
            end_jump = false;
            sm.ChangeState("Idle");
            //Hay que tener en cuenta que la obtencion del cameraShake
            //se esta haciendo a mano
            StartCoroutine(cameraShake.Shake(0.1f, 0.05f)); 
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
        if (_activo)
        {
            sm.ExecuteStateFixedUpdate();
            //no deja que el personaje rote cuando cae o cuando se desliza
            transform.rotation = Quaternion.identity;
            //BUG, sucede cuando una se acerca a un borde e inmediatamente suelta el movimiento, haciendo que el pj caiga en estado idle
            if (caer && sm.currentlyRunningState.GetNombre() == "Move")
            {
                time_falling += Time.deltaTime;
                if (time_falling >= TIME_FALLING)
                {
                    time_falling = 0f;
                    sm.ChangeState("Fall");
                }
            }
        }
    }

    public void Hurt(int dano){
        //Hacer golpe que tira para atras (rigid body?) e invencibilidad
        vida -= dano;

        if (vida <= 0){
            Destroy(gameObject, 2f); //after animation, poner tiempo de animacion nomas
            SceneManager.LoadScene("Main");
        }
        //StartCoroutine(Shake(1, 1.5f));
        ChangeHearths(vida);
    }

    //Cambia los corazones del HUD
    //1,2,3 así van los corazones
    void ChangeHearths(int vida)
    {
            switch (vida)
            {
                case 5:
                    tres.SetActive(false);
                    tres_medio.SetActive(true);
                    break;
                case 4:
                    tres_medio.SetActive(false);
                    tres_vacio.SetActive(true);
                    break;
                case 3:
                    dos.SetActive(false);
                    dos_medio.SetActive(true);
                    break;
                case 2:
                    dos_medio.SetActive(false);
                    dos_vacio.SetActive(true);
                    break;
                case 1:
                    uno.SetActive(false);
                    uno_medio.SetActive(true);
                    break;
                case 0:
                    uno_medio.SetActive(false);
                    uno_vacio.SetActive(true);
                    break;
            }
        
    }

    public void Heal(int heal)
    {
        vida = Math.Min(6, vida + heal);
        switch (vida)
        {
            case 6:
                tres.SetActive(true);
                tres_medio.SetActive(false);
                break;
            case 5:
                tres_medio.SetActive(true);
                tres_vacio.SetActive(false);
                break;
            case 4:
                dos.SetActive(true);
                dos_medio.SetActive(false);
                break;
            case 3:
                dos_medio.SetActive(true);
                dos_vacio.SetActive(false);
                break;
            case 2:
                uno.SetActive(true);
                uno_medio.SetActive(false);
                break;
        }
    }

    //deshabilita el pj por time segundos
    public void Wait(int time)
    {
        _activo = false;
        sm.ChangeState("Idle");
        _tiempo_necesario = time;
    }

    //Shake de HUD, bailen corazones, BAILEN!
    public IEnumerator Shake(float duration, float magnitude)
    {
        //valores iniciales

        float elapsed = 0f;

        while (elapsed < duration)
        {
            
            float x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
            float y = UnityEngine.Random.Range(-1f, 1f) * magnitude;
            Vector3 auxiliar = new Vector3(x, y, 0);
            switch (vida)
            {
                case 5:
                    tres_medio.transform.position += auxiliar;
                    dos.transform.position += auxiliar;
                    uno.transform.position += auxiliar;
                    break;
                case 4:
                    dos.transform.position += auxiliar;
                    uno.transform.position += auxiliar;
                    break;
                case 3:
                    dos_medio.transform.position += auxiliar;
                    uno.transform.position += auxiliar;
                    break;
                case 2:
                    uno.transform.position += auxiliar;
                    break;
                case 1:
                    uno_medio.transform.position += auxiliar;
                    break;
            }

            elapsed += Time.deltaTime;

            yield return null;
        }



        // volver a valores iniciales
        /*uno.transform.position = _posCorazon1;
        uno_medio.transform.position = _posCorazon1;
        dos.transform.position = _posCorazon2;
        dos_medio.transform.position = _posCorazon2;
        tres.transform.position = _posCorazon3;
        tres_medio.transform.position = _posCorazon3;*/
    }


    public IEnumerator ShakeHearth(float duration, float magnitude)
    {
        //valores iniciales

        float elapsed = 0f;

        while (elapsed < duration)
        {

            float x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
            float y = UnityEngine.Random.Range(-1f, 1f) * magnitude;
            Vector3 auxiliar = new Vector3(x, y, 0);


            elapsed += Time.deltaTime;

            yield return null;
        }
    }


    public void MakeSound(string sonido)
    {
        sonidos[sonido].Play();
    }

    public void StopSound(string sonido)
    {
        sonidos[sonido].Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pincho"))
        {
            if (!_yaColisiono)
            {
                //volver al checkpoint
                Hurt(1);
                transform.position = _lastCheckPoint;
                sm.ChangeState("Fall"); //No funciona
                _yaColisiono = true;
                collision.gameObject.GetComponent<PinchosClass>().ChangeSprite();
            }
        }
        else if (collision.CompareTag("CheckPoint"))
        {
            _lastCheckPoint = collision.gameObject.transform.position;  //Posicion es el centro del collision
        }
    }

}
