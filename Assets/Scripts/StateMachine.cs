using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IState currentlyRunningState;
    private string previousState;
    private Dictionary<string, IState> states;
    private PJController pjController;
    private Animator anim;
    public bool facingRight;

    public string animationRunning;

    public StateMachine(PJController pjController, Animator anim){
        this.states = new Dictionary<string, IState>();
        this.pjController = pjController;
        this.anim = anim;
        facingRight = true;

        // TODO revisar si es necesario pasar los anim
        states.Add("Idle", new Idle(pjController, anim, this, "Idle"));
        states.Add("Jump", new Jump(pjController, anim, this, "Jump"));
        states.Add("Crouch", new Crouch(pjController, anim, this, "Crouch"));
        states.Add("Move", new Move(pjController, anim, this, "Move"));
        states.Add("Attack", new Attack(pjController, anim, this, "Attack"));
        states.Add("Fall", new Fall(pjController, anim, this, "Fall"));
        
        currentlyRunningState = this.states["Idle"];
        previousState = "Idle";
    }

    public void ChangeState(string newState){
        currentlyRunningState.Exit();
        previousState = currentlyRunningState.GetNombre();
        currentlyRunningState = states[newState];
        currentlyRunningState.Enter();
    }
    
    /*  Cambia animacion del personaje y guarda cual es la actual
        la razon de esto es que animation no guarda el nombre y se necesita
        para saber que animacion llamo EventHandler() (Funcion de PJController)
    */
    public void ChangeAnimation(string newAnimation){
        this.animationRunning = newAnimation;        
        this.anim.Play(animationRunning);
    }

    public void ExecuteStateUpdate(){
        this.currentlyRunningState.Execute();
        
    }

    public void ExecuteStateFixedUpdate(){
        this.currentlyRunningState.FixedExecute();
        //Con este play de animacion se arregla el drama de derrapar
        this.anim.Play(animationRunning);
    }

    /*
        Cambia de direccion todo, pero solo a la direccion contraria
    */
    public void FlipX(string direction){
        if (this.facingRight == false && direction == "Right"){
            this.pjController.transform.localScale = new Vector3 (this.pjController.transform.localScale.x * -1, this.pjController.transform.localScale.y);
            this.facingRight = true;
        }
        else if (this.facingRight == true && direction == "Left"){
            this.pjController.transform.localScale = new Vector3 (this.pjController.transform.localScale.x * -1, this.pjController.transform.localScale.y);
            this.facingRight = false;
        }
    }
}
