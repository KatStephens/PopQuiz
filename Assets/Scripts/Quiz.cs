using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        DisplayQuestion();
    }
    public void OnAnswerSelected(int index) // Called when an answer button is clicked
    {
        Image buttonImage;

        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>(); // Get the image component of the button
            buttonImage.sprite = correctAnswerSprite; // Set the sprite of the button to the correct answer sprite
        }
        else
        {
            // get the correct answer index
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex); // Get the correct answer
            questionText.text = "Sorry, the correct answer was:\n " + correctAnswer; // Display the correct answer text on a new line
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>(); // Get the image component of the button
            buttonImage.sprite = correctAnswerSprite; // Set the sprite of the button to the correct answer sprite
        }

        SetButtonState(false); // Set the buttons to be not interactable
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }
    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state) // check each answer button and find which is the correct answer
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }

    }


    void SetDefaultButtonSprites(); //set default button sprite
    {    
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

}
