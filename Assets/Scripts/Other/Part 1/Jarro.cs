using UnityEngine;

public class Jarro : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
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
}
