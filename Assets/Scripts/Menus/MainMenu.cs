using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject options;

    private OptionMenu optionMenu;

    private Animator[] _animaciones;
    private int _pos;
    private int _pos_anterior;

    void Start()
    {
        _animaciones = transform.GetComponentsInChildren<Animator>();
        _pos = 0;
        _pos_anterior = 0;
        _animaciones[_pos].Play("Inicial");
        optionMenu = options.GetComponent<OptionMenu>();
    }

    void Comenzar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
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
                    //todo CONTINUAR
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
