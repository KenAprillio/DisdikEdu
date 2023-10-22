using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChainLightningScript : MonoBehaviour
{
    [TagSelector]
    public string TagFilter = "";
    public float damage;

    public GameObject chainLighningEffect;

    public GameObject beenStruck;

    public int amountToChain;

    private GameObject startObject;
    public GameObject endObject;

    public ParticleSystem parti;

    private int singleSpawn;

    // Start is called before the first frame update
    void Start()
    {
        parti = GetComponent<ParticleSystem>();
        startObject = gameObject;
        singleSpawn = 1;

        LightningToEnemy();
    }

    public void LightningToEnemy()
    {
        if (singleSpawn != 0)
        {
            endObject = GameObject.FindGameObjectWithTag("Enemy");

            if (!endObject.GetComponentInChildren<EnemyStruct>())
            {
                Instantiate(chainLighningEffect, gameObject.transform.position, Quaternion.identity);

                Instantiate(beenStruck, endObject.transform);

                endObject.GetComponent<EnemyScript>().TakeHit(damage);

                singleSpawn--;
                parti.Play();

                var emitParams = new ParticleSystem.EmitParams();
                emitParams.position = startObject.transform.position;

                parti.Emit(emitParams, 1);

                emitParams.position = endObject.transform.position;
                parti.Emit(emitParams, 1);

                emitParams.position = (startObject.transform.position + endObject.transform.position) / 2;
                parti.Emit(emitParams, 1);


                Destroy(gameObject, 1f);
            }
        }
    }


}
