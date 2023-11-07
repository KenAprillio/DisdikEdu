using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QuestionManager : MonoBehaviour
{

    // READ CSV DATA
    public TextAsset textJSON;

    [System.Serializable]
    public class Questions
    {
        [TextArea]
        public string questionText;
        public string answerA;
        public string answerB;
        public string answerC;
        public string answerD;
        public int correctAnswer;
    }

    [System.Serializable]
    public class QuestionList
    {
        public List<Questions> questionList;
    }

    public QuestionList questionDatabase = new QuestionList();
    // END READ CSV FILE

    public GameObject optionA;
    public GameObject optionB;
    public GameObject optionC;
    public GameObject optionD;


    public HealthScript healthScript;
    public GameObject[] options;

    public int currentQuestion = 0;

    GameObject player;
    public Animator animator;

    public TMP_Text questionField;

    public GameObject[] enemyPrefab;
    public GameObject enemySpawn;

    public BackgroundScript backgroundScript;

    public static QuestionManager Instance { get; private set; }


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        questionDatabase = JsonUtility.FromJson<QuestionList>(textJSON.text);
        //ReadCSV();
        player = GameObject.FindGameObjectWithTag("Player");
        //player.GetComponent<Animator>().SetTrigger("isNext");
        //generateQuestion();
        animator = GetComponent<Animator>();
    }

    public void Correct()
    {
        foreach (GameObject answers in options)
        {
            answers.GetComponent<Button>().interactable = false;
        }
        questionDatabase.questionList.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void Incorrect()
    {
        healthScript.health--;
    }

    // METHOD TO SET ANSWERS TO THE BUTTONS
    void SetAnswers()
    {
        optionA.transform.GetChild(0).GetComponent<TMP_Text>().text = questionDatabase.questionList[currentQuestion].answerA;
        optionA.GetComponent<AnswerScript>().correctAnswer = false;

        optionB.transform.GetChild(0).GetComponent<TMP_Text>().text = questionDatabase.questionList[currentQuestion].answerB;
        optionB.GetComponent<AnswerScript>().correctAnswer = false;

        optionC.transform.GetChild(0).GetComponent<TMP_Text>().text = questionDatabase.questionList[currentQuestion].answerC;
        optionC.GetComponent<AnswerScript>().correctAnswer = false;

        optionD.transform.GetChild(0).GetComponent<TMP_Text>().text = questionDatabase.questionList[currentQuestion].answerD;
        optionD.GetComponent<AnswerScript>().correctAnswer = false;


        switch (questionDatabase.questionList[currentQuestion].correctAnswer)
        {
            case 1:
                optionA.GetComponent<AnswerScript>().correctAnswer = true;
                break;
            case 2:
                optionB.GetComponent<AnswerScript>().correctAnswer = true;
                break;
            case 3:
                optionC.GetComponent<AnswerScript>().correctAnswer = true;
                break;
            case 4:
                optionD.GetComponent<AnswerScript>().correctAnswer = true;
                break;
        }
    }

    void EnemySpawn()
    {
        backgroundScript.MoveBackground();

        int enemy = Random.Range(0, enemyPrefab.Length);
        Debug.Log(enemy);
        GameObject newEnemy = Instantiate(enemyPrefab[0], enemySpawn.transform.position, transform.transform.rotation);
        newEnemy.transform.parent = GameObject.Find("Frame").transform;
    }

    // METHOD TO GENERATE NEXT QUESTION
    public void generateQuestion()
    {
        // SETS THE QUESTION ON THE QUESTION BOX BASED ON THE ARRAY JSON
        questionField.text = questionDatabase.questionList[currentQuestion].questionText;
        SetAnswers();

        // SET THE ANSWER BUTTONS INTERACTABLE
        foreach (GameObject answers in options)
        {
            answers.GetComponent<Button>().interactable = true;
        }

        currentQuestion++;
    }
}
