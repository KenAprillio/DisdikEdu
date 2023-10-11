using System;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;

    [System.Serializable]
    public class Question
    {
        [TextArea]
        public string question;
        public string answerA;
        public string answerB;
        public string answerC;
        public string answerD;
        public int correctAnswer;
    }

    [System.Serializable]
    public class QuestionsList
    {
        public Question[] question;
    }

    public QuestionsList questionList = new QuestionsList();

    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 6 - 1;
        questionList.question = new Question[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            questionList.question[i] = new Question();
            questionList.question[i].question = data[6 * (i + 1)];
            questionList.question[i].answerA = data[6 * (i + 1) + 1];
            questionList.question[i].answerB = data[6 * (i + 1) + 2];
            questionList.question[i].answerC = data[6 * (i + 1) + 3];
            questionList.question[i].answerD = data[6 * (i + 1) + 4];
            questionList.question[i].correctAnswer = int.Parse(data[6 * (i + 1) + 5]);
        }
    }

}
