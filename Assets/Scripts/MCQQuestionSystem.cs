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
    public GameObject[] objectsToAppear;    
    public int correctOptionIndex; // Index of the correct option in the dropdown

    private void Start()
    {
        // Hide all panels initially
        questionPanel.SetActive(true);
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
        foreach (GameObject obj in objectsToAppear)
            {
                obj.SetActive(true);
            }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void ShowCorrectAnswerPanel()
    {
        GameManagerL1.AddPoints();
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
