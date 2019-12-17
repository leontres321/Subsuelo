using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private BoxCollider2D cameraBox;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1024, 768, true);
        cameraBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("PJ").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        AspectRatioBoxChange();
        FollowPlayer();
    }

    void AspectRatioBoxChange(){
        //16:10
        if (Camera.main.aspect >= (1.6f) && Camera.main.aspect >= 1.7f){
            cameraBox.size = new Vector2(16.19f, 10.07f);
        }
        //16:9
        else if (Camera.main.aspect >= (1.7f) && Camera.main.aspect >= 1.8f){
            cameraBox.size = new Vector2(25.47f, 10.07f);
        }
        //5:4
        else if (Camera.main.aspect >= (1.25f) && Camera.main.aspect >= 1.3f){
            cameraBox.size = new Vector2(12.676f, 10.07f);
        }
        //4:3
        else if (Camera.main.aspect >= (1.3f) && Camera.main.aspect >= 1.4f){
            cameraBox.size = new Vector2(13.4718f, 10.07f);
        }
        //3:2
        else if (Camera.main.aspect >= (1.5f) && Camera.main.aspect >= 1.6f){
            cameraBox.size = new Vector2(15.211f, 10.07f);
        }
    }

    void FollowPlayer(){
        var aux = GameObject.Find("Boundary");
        if (aux){
            //TODO aca hay algo malo
            BoxCollider2D collider2D = aux.GetComponent<BoxCollider2D>();
            transform.position = new Vector3(Mathf.Clamp (player.position.x, collider2D.bounds.min.x + cameraBox.size.x / 2 , collider2D.bounds.max.x - cameraBox.size.x / 2),
                                            Mathf.Clamp (player.position.y, collider2D.bounds.min.y + cameraBox.size.y / 2 , collider2D.bounds.max.y - cameraBox.size.y / 2),
                                            transform.position.z);
        }
    }
}
