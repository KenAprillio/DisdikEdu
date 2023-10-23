using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool correctAnswer;
    //public QuestionManager questionManager;
    Animator ani;

    GameObject startObject;
    GameObject endObject;
    public GameObject lightningBolt;
    public GameObject lightningBoltToPlayer;
    private Vector2 InitialScale;

    //public GameObject chainLightningEffect;
    //ChainLightningScript chainLightning;

    PlayerScript player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

        InitialScale = lightningBolt.transform.localScale;

        startObject = gameObject;

        ani = GetComponent<Animator>();

        //chainLightning = GetComponent<ChainLightningScript>();
    }

    public void Answer()
    {
        if (correctAnswer)
        {
            Debug.Log("Correct Answer!");
            //questionManager.Correct();
            player.AttackEnemy();

            ani.SetTrigger("Correct");
            //Instantiate(chainLightningEffect, transform.position, Quaternion.identity);
            //chainLightning.LightningToEnemy();
        }
        else
        {
            Debug.Log("False Answer");
            QuestionManager.Instance.Incorrect();
            player.Hurt();
            ani.SetTrigger("False");

        }
    }

    void SpawnLightningBoltToEnemy(int isCorrect)
    {
        if (isCorrect == 0)
        {
            endObject = GameObject.FindGameObjectWithTag("Staff");
        } else
        {
            endObject = GameObject.FindGameObjectWithTag("Player");
        }
        startObject = gameObject;

        float distance = Vector3.Distance(startObject.transform.position, endObject.transform.position);


        lightningBolt.transform.localScale = new Vector3(InitialScale.x, distance);

        Vector3 middlePoint = (startObject.transform.position + endObject.transform.position) / 2f;
        Vector3 rotationDirection = (endObject.transform.position - startObject.transform.position);

        GameObject newLightningBolt = Instantiate(lightningBolt, middlePoint, Quaternion.identity);
        newLightningBolt.transform.up = rotationDirection;

        if (isCorrect == 0)
        {
            SpawnChainLightningBoltToEnemy();
        }
    }

    void SpawnChainLightningBoltToEnemy()
    {
        startObject = GameObject.FindGameObjectWithTag("Staff");
        endObject = GameObject.FindGameObjectWithTag("Enemy");

        float distance = Vector3.Distance(startObject.transform.position, endObject.transform.position);


        lightningBolt.transform.localScale = new Vector3(InitialScale.x, distance);

        Vector3 middlePoint = (startObject.transform.position + endObject.transform.position) / 2f;
        Vector3 rotationDirection = (endObject.transform.position - startObject.transform.position);

        GameObject newLightningBolt = Instantiate(lightningBolt, middlePoint, Quaternion.identity);

        newLightningBolt.transform.up = rotationDirection;
    }
}
