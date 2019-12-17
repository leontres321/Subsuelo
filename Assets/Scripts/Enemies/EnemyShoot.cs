using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{

    public GameObject bullet;

     float firerate;
     float nextfire;

    // Start is called before the first frame update
    void Start()
    {
        firerate = 1f;
        nextfire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Checktimetofire();
    }

    void Checktimetofire()
    {
        if (Time.time> nextfire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextfire = Time.time + firerate;
        }
    }
}
