using UnityEngine;

[CreateAssetMenu(menuName = "New Question")]
public class QuestionsAndAnswers : ScriptableObject
{
    [TextAreaAttribute]
    public string question;
    public string[] answers;
    public int correctAnswer;
}
