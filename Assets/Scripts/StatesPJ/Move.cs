using UnityEngine;
public class Move : StateClass, IState
{
    int direction;
    readonly float SPEED = 6f;
    int crouch;
    int attack;
    bool jump;

    float contador;
    int pisadaNumero;

    public Move(PJController pjController, Animator anim, StateMachine sm, string nombre) :
        base(pjController, anim, sm, nombre) { }
    public void Enter(){
        sm.ChangeAnimation("Move");
        direction = 0;
        crouch = 0;
        attack = 0;
        jump = false;
        contador = 0;
        pisadaNumero = 1;
    }

    public void Execute(){
        contador += Time.deltaTime;
        if (Input.GetButton("Down")){
            crouch = 1;
        }

        if (Input.GetButton("Attack")){
            attack = 1;
        }

        if (Input.GetButton("Jump")){
            jump = true;
        }

        if (Input.GetButton("Right")){
            direction = 1;
        }
        else if (Input.GetButton("Left")){
            direction = 2;
        }
        else{
            sm.ChangeState("Idle");
        }
        /*if (contador >= 0.1)
        {
            pjController.MakeSound("pisada_" + ((pisadaNumero % 2) + 1).ToString());
            pisadaNumero++;
            contador = 0;
        }*/
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
        if(attack == 1){
            sm.ChangeState("Attack");
            Stop();
        }
        else if(jump){
            sm.ChangeState("Jump");
        }
        else if(crouch == 1){
            sm.ChangeState("Crouch");
            Stop();
        }
    }
    
    public void Exit(){

        contador = 0;
        //pjController.StopSound("pisada_" + ((pisadaNumero % 2) + 1).ToString());
    }

    public void Stop(){
        pjController.rb.velocity = Vector2.zero;
    }
}
