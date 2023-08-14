using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerL1 : MonoBehaviour
{
    public GameObject Door1;
    private Animator doorAnimator;
    private bool isCursorLocked = true;
    public static int balance;
    public static int puzzlesolved = 0;
    public TMP_Text puzzlescore;
    public TMP_Text t_balance;
    public GameObject Teleporter;
    public GameObject PuzzleScorePanel;
    public GameObject TimelineTeleporter;
    bool TimelineComplete = false;
    private void Start()
    {
        balance = 0;
        LockUnlockCursor();
        doorAnimator = Door1.GetComponent<Animator>();;
    }
    public static void AddPoints()
    {
        balance += 50;
    }
    private void Update()
    {
        t_balance.text = "Token Balance: " + balance.ToString();
        puzzlescore.text = "Puzzle Solved: "+puzzlesolved.ToString();
        // Add any other input handling or game logic here

        // For example, you can press the "Escape" key to toggle cursor lock
        if (Input.GetKeyDown(KeyCode.M))
        {
            isCursorLocked = !isCursorLocked;
            LockUnlockCursor();
        }
        if(puzzlesolved == 2 && TimelineComplete==false)
        {
            PlayTeleporterTimeline();
        }
    }
    public void LockUnlockCursor()
    {
        if (isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void OpenDoor()
    {
        doorAnimator.SetBool("OpenDoor", true);
        StartCoroutine(DeactivateAfterTimeCoroutine(2, Door1));
    }
    private IEnumerator DeactivateAfterTimeCoroutine(float t,GameObject gb)
    {
        yield return new WaitForSeconds(t);
        gb.SetActive(false);
    }
    private IEnumerator DelayTime(float t)
    {
        yield return new WaitForSeconds(t);
        TimelineTeleporter.SetActive(false);
    }
    public void PlayTeleporterTimeline()
    {
        PuzzleScorePanel.SetActive(false);
        Debug.Log("PlayTeleporterTimeline");
        TimelineTeleporter.SetActive(true);
        StartCoroutine(DelayTime(5));
        
        Teleporter.SetActive(true);
        TimelineComplete = true;
        PuzzleScorePanel.SetActive(false);
    }
}
