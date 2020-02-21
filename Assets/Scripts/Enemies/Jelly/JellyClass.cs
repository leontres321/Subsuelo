using System.Collections.Generic;
using UnityEngine;

public class JellyClass : MonoBehaviour
{
    public Animator anim;
    public GameObject boundaryManager;
    public Rigidbody2D rb;
    public AudioClip audioIdle;
    public AudioClip audioMove;
    public AudioClip audioHurt;
    public AudioClip audioDie;
    public JellyMachine sm;

    int vida;

    AudioSource audioSource;
    Dictionary<string, AudioClip> sonidos;
    void Start()
    {
        //No se si esto es bueno para la memoria, pero la verdad no me importa tanto,
        //mala práctica?, quizas
        sonidos = new Dictionary<string, AudioClip>();
        sonidos.Add("Idle", audioIdle);
        sonidos.Add("Move", audioMove);
        sonidos.Add("Hurt", audioHurt);
        sonidos.Add("Die", audioDie);

        sm = new JellyMachine(gameObject.transform, anim, boundaryManager, rb, audioSource, sonidos);
        vida = 2;
        sm.ChangeState("Move");
        sm.darVuelta();
    }

    void Update()
    {
        sm.Execute();
    }

    void FixedUpdate()
    {
        sm.FixedExecute();    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword"))
        {
            sm.ChangeState("Hurt");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //dejo de tocar el piso
        if (collision.CompareTag("Floor"))
        {
            sm.darVuelta();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PJ"))
        {
            sm.pushBack();
        }
        
    }

    public void Hurt(int dano)
    {
        vida -= dano;
        if (vida < dano)
        {
            Die();
        }
        else
        {
            sm.pushBack();
        }
    }
    
    private void MakeSound(string sonido)
    {
        audioSource.PlayOneShot(sonidos[sonido]);
    }


    public void Die()
    {
        Destroy(gameObject, 20f); //Morir luego de 2 segundos
    }
}
