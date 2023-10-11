using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    float length, startpos;
    float dist;
    public float smoothness;

    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = background.GetComponent<SpriteRenderer>().bounds.size.x;
        dist = (length / 10);

    }

    public void MoveBackground()
    {
        Vector3 newPosition = new Vector3(transform.position.x - dist, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newPosition, smoothness);
    }
}
