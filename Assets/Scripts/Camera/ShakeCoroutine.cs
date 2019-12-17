using System.Collections;
using UnityEngine;

public class ShakeCoroutine : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        //Vector2 posicionInicial = transform.localPosition;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, -10);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = new Vector3(0, 0, -10);
    }
}
