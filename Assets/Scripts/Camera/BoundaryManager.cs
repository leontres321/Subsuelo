using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class BoundaryManager : MonoBehaviour
{

    private BoxCollider2D managerBox;
    private Transform player;


    public bool cambioIluminacion;
    public Light2D light;
    public GameObject boundary;
    public float nuevaIluminacion;
    // Start is called before the first frame update
    void Start()
    {
        managerBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("PJ").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        ManageBoundry();
    }

    void ManageBoundry(){
        if (managerBox.bounds.min.x < player.position.x && player.position.x < managerBox.bounds.max.x &&
            managerBox.bounds.min.y < player.position.y && player.position.y < managerBox.bounds.max.y){
                boundary.SetActive(true);
            if (cambioIluminacion)
            {
                light.intensity = nuevaIluminacion;
            }
        }
        else{
            boundary.SetActive(false);

        }
    }
}
