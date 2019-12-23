using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Mostrar que se obtuvo llave, o que se desbloqueo la puerta o algo asi
        var fx = gameObject.GetComponent<AudioSource>();
        fx.Play();
        
        var pj = GameObject.FindGameObjectWithTag("PJ").GetComponent<PJController>();
        pj.inventario.Agregar("SilverKey");
        pj.Wait(1);
        Destroy(gameObject, 1);
    }
}
