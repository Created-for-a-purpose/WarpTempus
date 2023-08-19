using UnityEngine;
using UnityEngine.UI;

public class ObjectsAppearDisappearOnCollision : MonoBehaviour
{
    public GameObject[] objectsToAppear;    // Array of objects to appear
    public GameObject[] objectsToDisappear; // Array of objects to disappear
    private void Start()
    {
        // Ensure the objects are initially hidden
        foreach (GameObject obj in objectsToAppear)
        {
            obj.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the specific GameObject
        if (other.CompareTag("Player"))
        {
            // Show the objects to appear
            foreach (GameObject obj in objectsToAppear)
            {
                obj.SetActive(true);
            }

            // Hide the objects to disappear
            foreach (GameObject obj in objectsToDisappear)
            {
                obj.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the collision with the specific GameObject
        if (other.CompareTag("Player"))
        {
            // Hide the objects to appear
            foreach (GameObject obj in objectsToAppear)
            {
                obj.SetActive(false);
            }

            // Show the objects to disappear
        }
    }
}
