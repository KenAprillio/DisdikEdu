using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChainLightningScript : MonoBehaviour
{
    /*[TagSelector]
    public string TagFilter = "";*/

    private GameObject lightningBolt;
    private Vector2 InitialScale;


    private GameObject startObject;
    public GameObject endObject;

    // Start is called before the first frame update
    void Start()
    {
        lightningBolt = gameObject;
        InitialScale = lightningBolt.transform.localScale;


        SpawnLightningBoltToEnemy();
    }

    void SpawnLightningBoltToEnemy()
    {
        startObject = GameObject.FindGameObjectWithTag("Staff");
        endObject = GameObject.FindGameObjectWithTag("Enemy");

        float distance = Vector3.Distance(startObject.transform.position, endObject.transform.position);


        lightningBolt.transform.localScale = new Vector3(InitialScale.x, distance);

        Vector3 middlePoint = (startObject.transform.position + endObject.transform.position) / 2f;
        Vector3 rotationDirection = (endObject.transform.position - startObject.transform.position);

        lightningBolt.transform.position = middlePoint;
        lightningBolt.transform.up = rotationDirection;
    }


}
