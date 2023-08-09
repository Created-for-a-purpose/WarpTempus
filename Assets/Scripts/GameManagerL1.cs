using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerL1 : MonoBehaviour
{
    public GameObject Door1;
    public GameObject PuzzleSpot1;
    private Animator doorAnimator;
    private bool isCursorLocked = true;

    private void Start()
    {
        LockUnlockCursor();
        doorAnimator = Door1.GetComponent<Animator>();;
    }
    private void Update()
    {
        // Add any other input handling or game logic here

        // For example, you can press the "Escape" key to toggle cursor lock
        if (Input.GetKeyDown(KeyCode.M))
        {
            isCursorLocked = !isCursorLocked;
            LockUnlockCursor();
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
}
