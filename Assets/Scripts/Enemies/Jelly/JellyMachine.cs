using System.Collections.Generic;
using UnityEngine;

//Me gustó el nombre
public class JellyMachine : EnemyStateMachine
{
    public JellyMachine(Transform enemy,
                        Animator animator,
                        GameObject boundary,
                        Rigidbody2D rb,
                        AudioSource audioSource,
                        Dictionary<string, AudioClip> sonidos)
    {
        _me = enemy;
        _anim = animator;
        this.boundary = boundary;
        rb.freezeRotation = true;
        _rb = rb;
        _audioSource = audioSource;
        _sonidos = sonidos;
        //Creacion del diccionario de estados
        enemyStates = new Dictionary<string, IEnemyState>();


        enemyStates.Add("Idle", new JellyIdle(rb, this, "Idle"));
        enemyStates.Add("Hurt", new JellyHurt(rb, this, "Hurt"));
        enemyStates.Add("Move", new JellyMove(rb, this, "Move"));

        currentlyRunningState = enemyStates["Move"];
        _animationRunning = "Move";
        previousState = "Idle";
    }

    public void pushBack()
    {
        int direccion = facingRight ? 1 : -1;
        int _pseudoFuerza = 2; 
        _rb.AddForce(direccion * _pseudoFuerza * Vector2.right);
    }
}
