using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool _activo;

    Options optiones;

    int int_position;
    Vector2 posicion;

    Vector2 PRIMERO = new Vector2(-5, 2.6f);
    Vector2 SEGUNDO = new Vector2(-5, 0.1f);
    Vector2 TERCERO = new Vector2(-5, -2.7f);

    void Start()
    {
        _activo = true;
        int_position = 0;
        posicion = new Vector2(190, 234);
    }

    void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }

    void Salir()
    {
        Application.Quit();
    }

    void Cambio()
    {
        _activo = false;

    }

    void Update()
    {
        if (_activo)
        {
            if (Input.GetButtonDown("Down"))
            {
                int_position++;
                if (int_position > 2) int_position = 2;
            }
            else if (Input.GetButtonDown("Up"))
            {
                int_position--;
                if (int_position < 0) int_position = 0;
            }

            switch (int_position)
            {
                case 0:
                    posicion = PRIMERO;
                    break;
                case 1:
                    posicion = SEGUNDO;
                    break;
                case 2:
                    posicion = TERCERO;
                    break;
            }
            gameObject.transform.position = posicion;

            if (Input.GetButtonDown("Accept"))
            {
                switch (int_position)
                {
                    case 0:
                        Jugar();
                        break;
                    case 1:
                        //TODO options
                        break;
                    case 2:
                        Salir();
                        break;
                }
            }
        }
        
    }
}
