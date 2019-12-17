using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PJController PJ = collision.gameObject.GetComponent<PJController>();
        if (PJ.inventario.Tiene("SilverKey"))
        {
            Destroy(gameObject);
        }
    }
}
