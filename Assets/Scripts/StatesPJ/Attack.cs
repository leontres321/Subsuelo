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
        //Cambiar de estado cuando esto sea true
        if (endAnimation){
            sm.ChangeState("Idle");
        }
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
