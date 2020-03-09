using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Jarro : MonoBehaviour
{
    private Animator _animator;
    public Light2D light2D;
    private float delta;
    private float timer;
    private float cambio;
    void Start()
    {
        cambio = 0.05f;
        timer = 0;
        delta = 1f;
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword"))
        {
            _animator.Play("Breaking");
            Destroy(gameObject, 0.5f);
            //todo: sonidos
            collision.gameObject.GetComponent<Espada>().Heal(1);
        }
    }

    private void Update()
    {
        if (timer >= delta)
        {
            timer = 0f;
            cambio *= -1;
        }
        else
        {
            timer += Time.deltaTime;
            light2D.pointLightOuterRadius += cambio;
        }
    }
}
