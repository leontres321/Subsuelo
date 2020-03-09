using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class CambioLuz : MonoBehaviour
{
    public Light2D light2D;
    public float delta;
    public float cambio;

    private float timer;
    void Start()
    {
        timer = 0;
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
