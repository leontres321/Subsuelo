using UnityEngine;

public class PinchosClass : MonoBehaviour
{
    public Sprite pinchosManchados;

    public void ChangeSprite()
    {
        GetComponent<SpriteRenderer>().sprite = pinchosManchados;
    }
}
