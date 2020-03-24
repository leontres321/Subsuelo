using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoActivación : MonoBehaviour
{
    bool _activo;
    void Start()
    {
        _activo = false;
    }

    public void active()
    {
        _activo = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_activo && collision.CompareTag("PJ"))
        {
            Destroy(gameObject);
        }
    }
}
