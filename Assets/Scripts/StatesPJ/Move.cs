using UnityEngine;
public class Move : StateClass, IState
{
    int direction;
    readonly float SPEED = 6f;
    int crouch;
    int attack;
    bool jump;

    public Move(PJController pjController, Animator anim, StateMachine sm, string nombre) :
        base(pjController, anim, sm, nombre) { }
    public void Enter(){
        this.sm.ChangeAnimation("Move");
        this.direction = 0;
        this.crouch = 0;
        this.attack = 0;
        this.jump = false;     
    }

    public void Execute(){
        if (Input.GetButton("Down")){
            this.crouch = 1;
        }

        if (Input.GetButton("Attack")){
            this.attack = 1;
        }

        if (Input.GetButton("Jump")){
            this.jump = true;
        }

        if (Input.GetButton("Right")){
            this.direction = 1;
        }
        else if (Input.GetButton("Left")){
            this.direction = 2;
        }
        else{
            this.sm.ChangeState("Idle");
        }
    }

    public void FixedExecute(){
        switch (direction)
        {
            case 1:
                pjController.rb.velocity = new Vector2(SPEED, pjController.rb.velocity.y);
                sm.FlipX("Right");
                break;
            case 2:
                pjController.rb.velocity = new Vector2(-SPEED, pjController.rb.velocity.y);
                sm.FlipX("Left");
                break;
            default:
                pjController.rb.velocity = Vector2.zero;
                break;
        }
        if(this.attack == 1){
            this.sm.ChangeState("Attack");
            Stop();
        }
        else if(this.jump){
            this.sm.ChangeState("Jump");
        }
        else if(this.crouch == 1){
            this.sm.ChangeState("Crouch");
            Stop();
        }
    }
    
    public void Exit(){
        
    }

    public void Stop(){
        pjController.rb.velocity = Vector2.zero;
    }
}
