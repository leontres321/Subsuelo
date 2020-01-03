using UnityEngine;
public class Crouch : StateClass, IState
{

    public Crouch(PJController pjController, Animator anim, StateMachine sm, string nombre) :
        base(pjController, anim, sm, nombre) { }
    public void Enter(){
        sm.ChangeAnimation("Crouch");
    }

    public void Execute(){
        if (Input.GetButtonUp("Down")){
            sm.ChangeState("Idle");
        }
    }

    public void FixedExecute(){
        
    }
    
    public void Exit(){
    }


    //para cuando caes libremente
    public void Wait(int time)
    {

    }
}
