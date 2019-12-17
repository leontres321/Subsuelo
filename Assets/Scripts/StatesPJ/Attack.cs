using UnityEngine;
public class Attack : StateClass, IState
{
    private bool endAnimation;
    private float timer;    
    public Attack(PJController pjController, Animator anim,  StateMachine sm) : base(pjController, anim, sm){
    }
    
    public void Enter(){
        this.sm.ChangeAnimation("Attack");        
    }

    public void Execute(){
        //Cambiar de estado cuando esto sea true
        if (endAnimation){
            sm.ChangeState("Idle");
        }
        this.timer += Time.deltaTime;
        if (this.timer >= 0.5f){
            this.endAnimation = true;
        }
    }

    public void FixedExecute(){
        
    }

    public void Exit(){
        this.endAnimation = false;
        this.timer = 0;
    }

    public void EndAnimation(){
        this.endAnimation = true;
    }
}
