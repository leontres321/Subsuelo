using UnityEngine;

public class PJController : MonoBehaviour
{
    public static StateMachine sm;
    public Animator anim;
    public bool end_jump;
    public Inventory inventario;

    int vida;
    private bool _activo;
    private float _timer;
    private int _tiempo_necesario;
    
    public Rigidbody2D rb;

    void Start(){
        end_jump = false;
        _activo = true;
        _timer = 0f;
        vida = 3;
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
        }
        
    }

    public void Hurt(int dano){
        //Hacer golpe que tira para atras (rigid body?) e invencibilidad
        vida -= dano;
        if (vida <= 0){
            Destroy(gameObject);
        }
    }

    public void Wait(int time)
    {
        _activo = false;
        sm.ChangeState("Idle");
        _tiempo_necesario = time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy_1"))
        {
            Hurt(1);
        }
    }
}
