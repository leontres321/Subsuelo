using UnityEngine;

public class ObjetoObjetoso : MonoBehaviour
{
    public ObjetoActivación oa;
    bool soloUnaVez = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PJ") || collision.CompareTag("Foot") && soloUnaVez)
        {
            soloUnaVez = true;
            oa.active();
            var fx = gameObject.GetComponent<AudioSource>();
            fx.Play();

            SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer>();
            sp.sprite = null;
            Destroy(gameObject, 1f);
        }
    }
}
