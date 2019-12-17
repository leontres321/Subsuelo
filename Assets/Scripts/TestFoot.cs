using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFoot : MonoBehaviour
{
    public PJController PJ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            PJ.end_jump = true;            
        }
    }

}
