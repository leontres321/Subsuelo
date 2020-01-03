using System.Collections;
using UnityEngine;

public class PJController : MonoBehaviour
{
    public static StateMachine sm;
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

    int vida;
    bool _activo;
    float _timer;
    int _tiempo_necesario;

    void Start(){
        end_jump = false;
        caer = false;
        _activo = true;
        _timer = 0f;
        vida = 6;
        sm = new StateMachine(this, anim);
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        rb = GetComponent<Rigidbody2D>();
        inventario = new Inventory();
    }

    void Update(){
        if (_activo)
        {
            sm.ExecuteStateUpdate();
            if (Input.GetButton("Exit"))
            {
                Application.Quit();
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
        if (_activo)
        {
            sm.ExecuteStateFixedUpdate();
            //no deja que el personaje rote cuando cae o cuando se desliza
            transform.rotation = Quaternion.identity;
            if (end_jump)
            {
                sm.ChangeState("Idle");
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                end_jump = false;
            }
            //TEST
            if (caer && sm.currentlyRunningState.GetNombre() == "Move")
            {
                sm.ChangeState("Fall");
            }
        }
    }

    public void Hurt(int dano){
        //Hacer golpe que tira para atras (rigid body?) e invencibilidad
        vida -= dano;
        if (vida <= 0){
            Destroy(gameObject); //after animation
        }
        for (int i = 0; i < dano; i++)
        {
            StartCoroutine(Shake(1, 1.5f));
            ChangeHearths(vida);
        }
    }

    //Cambia los corazones del HUD
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

    //deshabilita el pj por time segundos
    public void Wait(int time)
    {
        _activo = false;
        sm.ChangeState("Idle");
        _tiempo_necesario = time;
    }

    //llama a la funcion hud dependiendo de quien toco
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy_1"))
        {
            Hurt(1);
        }
        if (collision.gameObject.CompareTag("Enemy_1"))
        {
            Hurt(2);
        }

    }

    //Shake de HUD
    public IEnumerator Shake(float duration, float magnitude)
    {
        //valores iniciales
        Vector3 uno_inicial = uno.transform.position;
        Vector3 dos_inicial = dos.transform.position;
        Vector3 tres_inicial = tres.transform.position;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
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
        uno.transform.position = uno_inicial;
        uno_medio.transform.position = uno_inicial;
        dos.transform.position = dos_inicial;
        dos_medio.transform.position = dos_inicial;
        tres.transform.position = tres_inicial;
        tres_medio.transform.position = tres_inicial;
    }
}
