using UnityEngine;

public class Jump : StateClass, IState
{
    readonly float SPEED = 6f;
    readonly float _multiplicadorBajada = 0.05f; //todo: revisar
    bool _soltasteElBotonVithe;
    float _jumpForce = 550f;
    int direction;



    public Jump(PJController pjController, Animator anim, StateMachine sm, string nombre) :
        base(pjController, anim, sm, nombre) { }

    public void Enter(){
        pjController.rb.AddForce(new Vector2(0f, _jumpForce));
        sm.ChangeAnimation("Jump");
        direction = 0;
        _soltasteElBotonVithe = false;
    }

    // bienvenido al infierno
    public void Execute(){
        if (Input.GetButton("Right")){
            direction = 1;
        }
        else if(Input.GetButton("Left")){
            direction = 2;
        }
        if (Input.GetButtonUp("Left") || Input.GetButtonUp("Right")){
            direction = 0;
        }
        if (Input.GetButton("Attack")){
            sm.ChangeState("Attack");
        }
        if (Input.GetButtonUp("Jump"))
        {
            _soltasteElBotonVithe = true;
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
        if (_soltasteElBotonVithe)
        {
            pjController.rb.velocity += Vector2.up * Physics2D.gravity * _multiplicadorBajada;
        }
    }
    
    public void Exit(){
    }
}
