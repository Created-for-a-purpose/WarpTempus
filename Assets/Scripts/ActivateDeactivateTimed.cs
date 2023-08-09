using UnityEngine;

public class ActivateDeactivateTimed : MonoBehaviour
{
    public float s = 2.0f; // Time in seconds before activating the GameObject
    public float t = 2.0f; // Time in seconds before deactivating the GameObject
    public GameObject go;
    private void Start()
    {
        // Start the activation process
        go.SetActive(false);
        ActivateAfterDelay(s);
    }

    private void ActivateAfterDelay(float delay)
    {
        StartCoroutine(ActivateCoroutine(delay));
    }

    private System.Collections.IEnumerator ActivateCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Activate the GameObject after the specified delay
        go.SetActive(true);

        // Start the deactivation process after t seconds
        DeactivateAfterDelay(t);
    }

    private void DeactivateAfterDelay(float delay)
    {
        StartCoroutine(DeactivateCoroutine(delay));
    }

    private System.Collections.IEnumerator DeactivateCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Deactivate the GameObject after the specified delay
        go.SetActive(false);
    }
}
