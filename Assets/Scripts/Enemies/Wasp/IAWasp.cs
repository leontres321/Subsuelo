using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class IAWasp : MonoBehaviour
{
    public Transform player;
    public float speed = 50f;
    public float next_way_point = 3;
    public GameObject boundary;
    public Transform enemy;
    public AudioSource audio;

    bool activo;
    Path path;
    int current_way_point = 0;
    bool reached_end = false;
    Vector2 _initialPoint;
    
    Seeker seeker;
    Rigidbody2D rigid_body;
    
    void Start()
    {
        _initialPoint = transform.position;
        seeker = GetComponent<Seeker>();
        rigid_body = GetComponent<Rigidbody2D>();

        //funcion a hacer, cuando parte y delta tiempo
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath(){
        if (activo){
            if(seeker.IsDone() && player != null){
                seeker.StartPath(rigid_body.position, player.position, OnPathComplete);
            }
        }
    }

    void Update()
    {
        if(boundary.activeSelf){
            activo = true;
            audio.Play();
        }
        else{
            activo = false;
            ReturnInitialPosition();
        }
    }

    void FixedUpdate()
    {
        if(activo){
            if (path == null){
                return;
            }

            if (current_way_point >= path.vectorPath.Count){
                reached_end = true;
                return;
            }
            else{
                reached_end = false;
            }

            Vector2 direction = ((Vector2)path.vectorPath[current_way_point] - rigid_body.position).normalized;
            Vector2 force = direction * speed;

            rigid_body.AddForce(force);

            float distance = Vector2.Distance(rigid_body.position, path.vectorPath[current_way_point]);

            if (distance < next_way_point){
                current_way_point++;
            }

            if (force.x >= 0.01f){
                enemy.localScale = new Vector3(-1f, 1f, 1f);
            }
            else{
                enemy.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

    void OnPathComplete(Path p){
        if (!p.error){
            path = p;
            current_way_point = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sword"){
            Destroy(gameObject);
        }
    }

    void ReturnInitialPosition()
    {
        transform.position = _initialPoint;
    }
}
