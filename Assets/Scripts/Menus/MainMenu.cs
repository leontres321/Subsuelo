using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject options;
    [SerializeField]
    GameObject cargando;
    [SerializeField]
    GameObject titulo;
    [SerializeField]
    GameObject comoJugar;


    private OptionMenu optionMenu;

    private Animator[] _animaciones;
    private int _pos;
    private int _pos_anterior;

    void Start()
    {
        _animaciones = transform.GetComponentsInChildren<Animator>();
        _pos = 0;
        _pos_anterior = 0;
        try
        {
            _animaciones[_pos].Play("Inicial");
        }
        catch (Exception e)
        {
            Debug.Log(e);
            Debug.Log("Bug: array de animaciones aparece vacio, mas raro aun esta funcion se ejecuta al ocultar el objeto");
        }
        optionMenu = options.GetComponent<OptionMenu>();
    }

    void Comenzar()
    {
        titulo.SetActive(false);
        cargando.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameObject.SetActive(false);
    }

    void Salir()
    {
        Application.Quit();
    }
    
    void Cambio()
    {
        options.SetActive(true);
        optionMenu.Iniciar();
        gameObject.SetActive(false);
    }

    void ComoJugar()
    {
        comoJugar.SetActive(true);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Down"))
        {
            _pos_anterior = _pos++;
            if (_pos > 3)
            {
                _pos = 3;
                _animaciones[_pos].Play("Inicial");
            }
        }
        else if (Input.GetButtonDown("Up"))
        {
            _pos_anterior = _pos--;
            if (_pos < 0)
            {
                _pos = 0;
                _animaciones[_pos].Play("Inicial");
            }
        }

        if (_pos != _pos_anterior)
        {
            _animaciones[_pos_anterior].Play("Idle");
            _animaciones[_pos].Play("Active");
        }
        
        if (Input.GetButtonDown("Accept"))
        {
            switch (_pos)
            {
                case 0:
                    Comenzar();
                    break;
                case 1:
                    ComoJugar();
                    break;
                case 2:
                    Cambio();
                    break;
                case 3:
                    Salir();
                    break;
            }
        }
        
    }
}
