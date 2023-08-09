using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MCQQuestionSystem : MonoBehaviour
{
    public GameObject questionPanel;
    public GameObject correctAnswerPanel;
    public GameObject wrongAnswerPanel;
    public GameObject PuzzleSpot;
    public TMP_Dropdown dropdown;
    public int correctOptionIndex; // Index of the correct option in the dropdown

    private void Start()
    {
        // Hide all panels initially
        questionPanel.SetActive(true);
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(false);
    }

    public void SubmitAnswer()
    {
        int selectedOptionIndex = dropdown.value;

        if (selectedOptionIndex == correctOptionIndex)
        {
            ShowCorrectAnswerPanel();
        }
        else
        {
            ShowWrongAnswerPanel();
        }
    }
    public void Next()
    {
        questionPanel.SetActive(false);
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(false);
        PuzzleSpot.SetActive(false); 
    }

    private void ShowCorrectAnswerPanel()
    {
        questionPanel.SetActive(false);
        correctAnswerPanel.SetActive(true);
        wrongAnswerPanel.SetActive(false);
    }

    private void ShowWrongAnswerPanel()
    {
        questionPanel.SetActive(false);
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(true);
    }

    public void ShowQuestionPanel()
    {
        questionPanel.SetActive(true);
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(false);
    }
}
