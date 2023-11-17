using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    float length, startpos;
    float dist;
    public float duration;

    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = background.GetComponent<SpriteRenderer>().bounds.size.x;
        dist = (length / 5);

    }

    public void MoveBackground()
    {
        StartCoroutine(BackgroundMoving());
    }

    IEnumerator BackgroundMoving()
    {
        float timeElapsed = 0;
        Vector3 newPosition = new Vector3(transform.position.x - dist, transform.position.y, transform.position.z);


        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;

            transform.position = Vector3.Lerp(transform.position, newPosition, t);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = newPosition;
    }
}
