using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class WaspController : MonoBehaviour
{
    public AIPath aiPath;
    private Vector2 DISTANCIA_GOLPE = new Vector2(70.71f, 70.71f);
    public GameObject my_boundary;
    private bool active = false;
    private float SPEED = 20.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        //corre de todas formas 1 vez al correr el juego, bug?
        active = my_boundary.activeSelf;

        if (aiPath.desiredVelocity.x >= 0.01f){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else{
            transform.localScale = new Vector3(1f, 1f, 1f);
        }


    }

    void FixedUpdate(){
        if (active){
            Attack();
        }
    }

    void Attack(){
        //maldad
    }
}
