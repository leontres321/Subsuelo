using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public IEnemyState currentlyRunningState;
    public string previousState;   
    public Dictionary<string, IEnemyState> enemyStates;

    bool _active = false;
    bool _wait = false;
    float _timer;
    float _timeToWait;

    protected Rigidbody2D _rb;
    protected Animator _anim;
    //Para poder hacer flip del transform
    protected Transform _me;
    protected string _animationRunning;
    protected GameObject boundary;

    //Para los sonidos
    protected Dictionary<string, AudioClip> _sonidos;
    protected AudioSource _audioSource;

    public bool facingRight;

    public void Execute()
    {
        //revisa si el boundary que lo contiene está activo
        //de ser asi el monito funciona
        _active = boundary.activeInHierarchy;
        if (_active)
        {
            //si le dicen que espere entonces, espera ese tiempo
            if (_wait)
            {
                _timer += Time.deltaTime;
                _active = false;
                if (_timer >= _timeToWait)
                {
                    _wait = false;
                    _timeToWait = 0f;
                }
            }
            //sino debe esperar entonces se mueve
            else
            {
                currentlyRunningState.Execute();
            }
                
        }
    }

    public void FixedExecute()
    {
        if (_active)
        {
            currentlyRunningState.FixedExecute();
            _anim.Play(_animationRunning);
        }
    }

    /// <summary>
    /// Cambia de estado actual a un nuevo estado, usando sus exit() y enter respectivos
    /// </summary>
    /// <param name="newState">Nombre del nuevo estado</param>
    public void ChangeState(string newState)
    {
        currentlyRunningState.Exit();
        previousState = currentlyRunningState.GetName();
        currentlyRunningState = enemyStates[newState];
        currentlyRunningState.Enter();
    }

    /// <summary>
    /// Cambia animacion actual a una nueva y la recuerda
    /// </summary>
    /// <param name="newAnimation">Nombre de la nueva animacion</param>
    public void ChangeAnimation(string newAnimation)
    {
        _animationRunning = newAnimation;
        _anim.Play(_animationRunning);
    }

    /// <summary>
    /// Gira al personaje en su eje X
    /// </summary>
    /// <param name="direction">Hacia donde debe girar</param>
    public void FlipX(string direction)
    {
        if (facingRight == false && direction == "Right")
        {
            _me.localScale = new Vector3(_me.localScale.x * -1, _me.localScale.y);
            facingRight = true;
        }
        else if (facingRight == true && direction == "Left")
        {
            _me.localScale = new Vector3(_me.localScale.x * -1, _me.localScale.y);
            facingRight = false;
        }
    }

    /// <summary>
    /// Cambia de direccion en la que mira el personaje
    /// </summary>
    public void darVuelta()
    {
        if (facingRight)
        {
            FlipX("Left");
        }
        else
        {
            FlipX("Right");
        }
    }

    /// <summary>
    /// Espera una cantidad de tiempo 
    /// </summary>
    /// <param name="time">Tiempo en segundos</param>
    public void Wait(float time)
    {
        _timeToWait = time;
        _wait = true;
        _timer = 0f;
    }

    public void MakeSound(string sonido)
    {
        
    }

}

