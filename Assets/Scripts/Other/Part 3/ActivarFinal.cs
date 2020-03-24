using UnityEngine;

public class ActivarFinal : MonoBehaviour
{
    public FinalBoss finalJefazo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Foot"))
        {
            finalJefazo.activar();
            Destroy(gameObject);
        }
    }
}
