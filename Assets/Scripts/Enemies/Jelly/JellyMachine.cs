using UnityEngine;

//Me gustó el nombre
public class JellyMachine : EnemyStateMachine
{
    public JellyMachine(Transform enemy, Animator animator, GameObject boundary, AudioClip[] audios, Rigidbody2D rb)
    {
        _me = enemy;
        _anim = animator;
        this.boundary = boundary;
        

        //Creacion del diccionario
        enemyStates.Add("Idle", new JellyIdle(rb, audios[0], this, "Idle"));

    }
}
