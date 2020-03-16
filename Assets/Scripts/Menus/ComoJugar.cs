using UnityEngine;

public class ComoJugar : MonoBehaviour
{
    [SerializeField]
    GameObject menuInical;

    void Update()
    {
        if (Input.GetButtonDown("Exit"))
        {
            menuInical.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
