using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterTrigger : MonoBehaviour
{
    public string sceneToLoad = "Colonial_graveyard";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadTargetScene();
        }
    }

    private void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
