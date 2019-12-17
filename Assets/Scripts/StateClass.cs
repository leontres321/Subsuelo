using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateClass
{   
    //Raro pero si se ponen en privados unity no te deja correr el script
    public PJController pjController;
    public Animator anim;
    public StateMachine sm;
    
    public StateClass(PJController pjController, Animator anim, StateMachine sm){
        this.pjController = pjController;
        this.anim = anim; 
        this.sm = sm;
    }
}
