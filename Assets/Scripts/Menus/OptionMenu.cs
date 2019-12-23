using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    
    [SerializeField]
    GameObject main;

    private float _deltaVolume;

    private int _pos;
    private int _pos_anterior;
    private Animator[] _animaciones;
    
    void Start()
    {
        _pos = 1;
        _pos_anterior = 1;
        _deltaVolume = 0.5f;
        _animaciones = transform.GetComponentsInChildren<Animator>();

        slider.normalizedValue = AudioListener.volume;
        Iniciar();
    }

    void Update()
    {
        //_pos = 1 => volumen
        //_pos = 2 => volver

        if (Input.GetButtonDown("Down"))
        {
            _pos_anterior = _pos++;
            if (_pos > 2)
            {
                _pos = 2;
                _animaciones[_pos].Play("Inicial");
            }
        }
        else if (Input.GetButtonDown("Up"))
        {
            _pos_anterior = _pos--;
            if (_pos < 1)
            {
                _pos = 1;
                _animaciones[_pos].Play("Inicial");
            }
        }

        //cambiar foco
        if (_pos != _pos_anterior)
        {
            _animaciones[_pos_anterior].Play("Idle");
            _animaciones[_pos].Play("Active");
        }


        //Cambiar audio
        if (_pos == 1 && (Input.GetButton("Left") || Input.GetButton("Right")))
        {
            int signo = Input.GetButton("Left") ? -1 : 1;
            slider.normalizedValue += Time.deltaTime * signo * _deltaVolume;
        }

        //revision de focus y acciones anexas
        switch (_pos)
        {
            case 1:
                CambiarVolumen();
                break;
            case 2:
                if (Input.GetButtonDown("Accept"))
                {
                    Regresar();
                }
                break;
        }
    }


    public void Iniciar()
    {
        _pos = 1;
        _pos_anterior = 1;

        //Este check esta porque la primera vez que llamamos a optionMenu no ha pasado por Start
        //por lo tanto las animaciones son nulas
        if (_animaciones != null)
        {
            _animaciones[0].Play("Inicial");
            _animaciones[1].Play("Inicial");
        }
    }

    private void CambiarVolumen()
    {
        //sí, con horizontal sería más facil 
        int subir = Input.GetButton("Right") ? 1 : 0;
        int bajar = Input.GetButton("Left") ? -1 : 0;
        slider.normalizedValue += Time.deltaTime * (subir + bajar);
        AudioListener.volume = slider.normalizedValue;
    }

    private void Regresar()
    {
        main.SetActive(true);
        gameObject.SetActive(false);
    }

}
