using UnityEngine;
public class Idle : StateClass, IState
{   
    

    public Idle(PJController pjController, Animator anim,  StateMachine sm, string nombre) : 
        base(pjController, anim, sm, nombre){}

    public void Enter(){
        pjController.rb.velocity = new Vector2(0, pjController.rb.velocity.y);
        this.sm.ChangeAnimation("Idle");
    }

    public void Execute(){
        if (Input.GetButtonDown("Down")){ 
            sm.ChangeState("Crouch");
        }
        else if (Input.GetButton("Attack")){
            sm.ChangeState("Attack");
        }
        else if (Input.GetButton("Left") || Input.GetButton("Right")){
            sm.ChangeState("Move");
        }
        else if (Input.GetButtonDown("Jump")){
            sm.ChangeState("Jump");
        }
    }

    public void FixedExecute(){
        
    }
    
    public void Exit(){
    }
}
