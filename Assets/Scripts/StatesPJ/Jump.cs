using UnityEngine;

public class Jump : StateClass, IState
{
    private readonly float SPEED = 6f;
    private float _jumpForce = 550f;
    private int direction;

    public Jump(PJController pjController, Animator anim,  StateMachine sm) : base(pjController, anim, sm){
    }
    public void Enter(){
        pjController.rb.AddForce(new Vector2(0f, _jumpForce));
        this.sm.ChangeAnimation("Jump");
        this.direction = 0;
    }

    public void Execute(){
        if (Input.GetButton("Right")){
            this.direction = 1;
        }
        else if(Input.GetButton("Left")){
            this.direction = 2;
        }
        if (Input.GetButtonUp("Left") || Input.GetButtonUp("Right")){
            this.direction = 0;
        }
        if (Input.GetButton("Attack")){
            this.sm.ChangeState("Attack");
        }
    }

    public void FixedExecute(){
        switch (direction)
        {
            case 1:
                pjController.rb.velocity = new Vector2(SPEED, pjController.rb.velocity.y);
                this.sm.FlipX("Right");
                break;
            case 2:
                pjController.rb.velocity = new Vector2(-SPEED, pjController.rb.velocity.y);
                this.sm.FlipX("Left");
                break;
            default:
                pjController.rb.velocity = new Vector2(0, pjController.rb.velocity.y);
                break;
        }
    }
    
    public void Exit(){

    }
}
