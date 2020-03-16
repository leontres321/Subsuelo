using System;
using UnityEngine;
/// <summary>
/// Este objeto solo se encargará de los fantasmas pero podría ser expandido a otras cosas
/// </summary>
public class BolsaDeFantasmas : MonoBehaviour
{
    public static BolsaDeFantasmas singleton;

    private void Awake()
    {
        //Definimos la variable como el mismo y pim pam pum, singleton
        singleton = this;
    }

    public event Action RegresarPosicionInicial;
    public void RegresarFantasmas()
    {
        RegresarPosicionInicial?.Invoke();
    }

}
