using UnityEngine;

public class Fall : StateClass, IState
{
    int direction;
    readonly float SPEED = 6f;
    bool cambio;

    public Fall(PJController pjController, Animator anim, StateMachine sm, string nombre) :
        base(pjController, anim, sm, nombre){ }


    public void Enter()
    {
        sm.ChangeAnimation("Fall");
        direction = 0;
        cambio = false;
    }

    public void Execute()
    {
        if (Input.GetButton("Right"))
        {
            direction = 1;
        }
        else if (Input.GetButton("Left"))
        {
            direction = 2;
        }
        else
        {
            direction = 0;
        }
        cambio = !pjController.caer;
    }

    public void FixedExecute()
    {
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
            case 0:
                pjController.rb.velocity = new Vector2(0, pjController.rb.velocity.y);
                break;
        }
        if (cambio)
        {
            sm.ChangeState("Idle");
        }
    }


    public void Exit()
    {
        
    }
}
