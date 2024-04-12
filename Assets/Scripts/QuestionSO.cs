using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question text here"; // array of strings for the answers
    [SerializeField] string[] answers = new string[4]; // index of the correct answer
    [SerializeField] int correctAnswerIndex;

    // Getter method for the question
    // return the question
    public string GetQuestion()
    {
        return question;
    }
  
    // Getter method to get the answer called 'GetAnswer'
    // return the answer at the given index
    public string GetAnswer(int index)
    {
        return answers[index];
    }       

    // Getter method for the correct answer index called 'GetCorrectAnswerIndex'
    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
            

}

