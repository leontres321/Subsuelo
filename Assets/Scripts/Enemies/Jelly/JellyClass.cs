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

    JellyMachine sm;
    
    void Start()
    {
        //No se si esto es bueno para la memoria, pero la verdad no me importa tanto,
        //mala práctica?, quizas
        AudioClip[] audios = new AudioClip[4];
        audios[0] = audioIdle;
        audios[1] = audioMove;
        audios[2] = audioHurt;
        audios[3] = audioDie;
        sm = new JellyMachine(gameObject.transform, anim, boundaryManager, audios, rb);
    }

    void Update()
    {
        sm.Execute();
    }

    void FixedUpdate()
    {
        sm.FixedExecute();    
    }
}
