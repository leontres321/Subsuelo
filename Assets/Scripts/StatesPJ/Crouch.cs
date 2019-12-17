using UnityEngine;
public class Crouch : StateClass, IState
{
    private bool down;
    public Crouch(PJController pjController, Animator anim,  StateMachine sm) : base(pjController, anim, sm){
    }
    public void Enter(){
        this.sm.ChangeAnimation("Crouch");
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
}
