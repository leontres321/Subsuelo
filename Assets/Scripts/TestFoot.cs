﻿using UnityEngine;

public class TestFoot : MonoBehaviour
{
    public PJController PJ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            PJ.end_jump = true;
            PJ.caer = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            PJ.caer = true;
        }
    }

}
