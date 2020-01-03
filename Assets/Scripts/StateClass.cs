using UnityEngine;

public class StateClass
{   
    //Raro pero si se ponen en privados unity no te deja correr el script
    public PJController pjController;
    public Animator anim;
    public StateMachine sm;

    //Utilizado para saber quien es estado anterior
    public string nombre;
    
    public StateClass(PJController pjController, Animator anim, StateMachine sm, string nombre){
        this.pjController = pjController;
        this.anim = anim; 
        this.sm = sm;
        this.nombre = nombre;
    }

    public string GetNombre()
    {
        return nombre;
    }
}
