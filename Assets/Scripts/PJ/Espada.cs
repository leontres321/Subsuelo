using UnityEngine;

public class Espada : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy_1"))
        {
            var clase = collision.gameObject.GetComponent<JellyClass>();
            clase.sm.pushBack();
        }
    }
}
