using UnityEngine;

public class MouseCheck : MonoBehaviour
{
    public GameObject[] objectsToCheck; // Array of GameObjects to check

    private void Update()
    {
        bool anyObjectActive = false;

        // Check if any of the GameObjects is active
        foreach (GameObject obj in objectsToCheck)
        {
            if (obj.activeSelf)
            {
                anyObjectActive = true;
                break;
            }
        }

        // Lock the cursor and hide it if any GameObject is active
        if (anyObjectActive)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
