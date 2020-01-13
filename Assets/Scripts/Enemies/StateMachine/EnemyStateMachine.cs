using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public IEnemyState currentlyRunningState;
    public string previousState;   

    bool _active = false;
    bool _wait = false;
    bool _facingRight;
    float _timer;
    float _timeToWait;
    
    protected Dictionary<string, IEnemyState> enemyStates;
    protected Animator _anim;
    //Para poder hacer flip del transform
    protected Transform _me;
    protected string _animationRunning;
    protected GameObject boundary;

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

    public void ChangeState(string newState)
    {
        currentlyRunningState.Exit();
        previousState = currentlyRunningState.GetName();
        currentlyRunningState = enemyStates[newState];
        currentlyRunningState.Enter();
    }

    public void ChangeAnimation(string newAnimation)
    {
        _animationRunning = newAnimation;
        _anim.Play(_animationRunning);
    }

    public void FlipX(string direction)
    {
        if (_facingRight == false && direction == "Right")
        {
            _me.localScale = new Vector3(_me.localScale.x * -1, _me.localScale.y);
            _facingRight = true;
        }
        else if (_facingRight == true && direction == "Left")
        {
            _me.localScale = new Vector3(_me.localScale.x * -1, _me.localScale.y);
            _facingRight = false;
        }
    }


    public void Wait(float time)
    {
        _timeToWait = time;
        _wait = true;
        _timer = 0f;
    }
}

