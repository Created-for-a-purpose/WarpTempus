using UnityEngine;
using UnityEngine.UI;

public class ButtonAppearOnCollision : MonoBehaviour
{
    public GameObject buttonToAppear;

    private void Start()
    {
        // Ensure the button is initially hidden
        buttonToAppear.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the specific GameObject
        if (other.CompareTag("Player"))
        {
            // Show the button
            buttonToAppear.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the collision with the specific GameObject
        if (other.CompareTag("Player"))
        {
            // Hide the button
            buttonToAppear.SetActive(false);
        }
    }
}
