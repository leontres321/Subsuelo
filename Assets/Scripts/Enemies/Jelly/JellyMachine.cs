using System.Collections.Generic;
using UnityEngine;

//Me gustó el nombre
public class JellyMachine : EnemyStateMachine
{
    public JellyMachine(Transform enemy, Animator animator, GameObject boundary, AudioClip[] audios, Rigidbody2D rb)
    {
        _me = enemy;
        _anim = animator;
        this.boundary = boundary;
        rb.freezeRotation = true;

        //Creacion del diccionario
        enemyStates = new Dictionary<string, IEnemyState>();

        enemyStates.Add("Idle", new JellyIdle(rb, audios[0], this, "Idle"));

        currentlyRunningState = enemyStates["Idle"];
        _animationRunning = "Idle";
        previousState = "Idle";
    }
}
