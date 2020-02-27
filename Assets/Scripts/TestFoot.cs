using UnityEngine;

public class TestFoot : MonoBehaviour
{
    public PJController PJ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            PJ.end_jump = true;
            PJ.caer = false;
            PJ.time_falling = 0f;
            PJ.MakeSound("caida");
            PJ._yaColisiono = false;
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
