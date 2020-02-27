using UnityEngine;
public class Attack : StateClass, IState
{
    private bool endAnimation;
    private float timer;    
    public Attack(PJController pjController, Animator anim, StateMachine sm, string nombre) :
        base(pjController, anim, sm, nombre){ }

    public void Enter(){
        sm.ChangeAnimation("Attack");
        pjController.MakeSound("espada");
    }

    public void Execute(){
        if ((sm.previousState == "Fall" || sm.previousState == "Jump") && endAnimation)
        {
            sm.ChangeState("Fall");
        }
        else if (endAnimation){
            sm.ChangeState("Idle");
        }
        //Duracion de animacion
        timer += Time.deltaTime;
        if (timer >= 0.5f){
            endAnimation = true;
        }
    }

    public void FixedExecute(){
        
    }

    public void Exit(){
        endAnimation = false;
        timer = 0;
    }

    public void EndAnimation(){
        endAnimation = true;
    }
}
