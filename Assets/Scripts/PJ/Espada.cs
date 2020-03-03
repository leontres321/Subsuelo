using UnityEngine;

public class Espada : MonoBehaviour
{
    public PJController PJ;

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void Heal(int vida)
    {
        PJ.Heal(vida);
    }
}
