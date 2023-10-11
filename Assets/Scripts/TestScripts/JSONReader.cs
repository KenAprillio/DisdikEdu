using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
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
        public Questions[] questionList;
    }

    public QuestionList questionDatabase = new QuestionList();


    // Start is called before the first frame update
    void Start()
    {
        questionDatabase = JsonUtility.FromJson<QuestionList>(textJSON.text);
    }
}
