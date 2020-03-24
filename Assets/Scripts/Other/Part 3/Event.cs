using System;
using UnityEngine;

public class Event : MonoBehaviour
{
    public static Event singleton;
    public GameObject boundary;

    public GameObject fantasma1;
    public GameObject fantasma2;
    public GameObject fantasma3;
    public GameObject fantasma4;
    public GameObject fantasma5;
    public GameObject fantasma6;
    public GameObject fantasma7;
    public GameObject fantasma8;
    public GameObject fantasma9;
    public GameObject fantasma10;

    public GameObject puerta;

    float contador;
    float tiempoAparicion;
    int fantasmaASalir;

    private void Awake()
    {
        //Definimos la variable como el mismo y pim pam pum, singleton
        singleton = this;
        contador = 0f;
        tiempoAparicion = 1.3f;
        fantasmaASalir = 1;
    }


    private void Update()
    {
        if (boundary.activeSelf)
        {
            contador += Time.deltaTime;
            if (contador >= tiempoAparicion)
            {
                //Fantasmas aparecerán más rápido, se podia hacer de mejor manera?, si, pero ya vale verga
                contador = 0f;
                switch (fantasmaASalir)
                {
                    case 1:
                        fantasma1.SetActive(true);
                        break;
                    case 2:
                        fantasma2.SetActive(true);
                        break;
                    case 3:
                        fantasma3.SetActive(true);
                        break;
                    case 4:
                        fantasma4.SetActive(true);
                        break;
                    case 5:
                        fantasma5.SetActive(true);
                        break;
                    case 6:
                        fantasma6.SetActive(true);
                        break;
                    case 7:
                        fantasma7.SetActive(true);
                        break;
                    case 8:
                        fantasma8.SetActive(true);
                        break;
                    case 9:
                        fantasma9.SetActive(true);
                        break;
                    case 10:
                        fantasma10.SetActive(true);
                        break;
                    case 11:
                        fantasmaASalir--;
                        if (!fantasma10.activeSelf && !fantasma9.activeSelf && !fantasma8.activeSelf)
                        {
                            Destroy(gameObject, 1f);
                            AudioSource sonido = GetComponent<AudioSource>();
                            sonido.Play();
                            Destroy(puerta);
                        }
                        break;
                }
                fantasmaASalir++;
            }
        }
    }



    public event Action RegresarPosicionInicial;
    public void RegresarFantasmas()
    {
        RegresarPosicionInicial?.Invoke();
        fantasmaASalir = 1;
    }

}