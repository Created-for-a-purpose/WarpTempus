using UnityEngine;
using UnityEngine.UI;
using System.Text;
using TMPro;

public enum GreekGod
{
    Zeus,
    Hera,
    Poseidon,
    Demeter,
    Athena,
    Apollo,
    Artemis,
    Ares,
    Aphrodite,
    Hades,
    Hermes,
    Dionysus
}

public class CollectGreekGods : MonoBehaviour
{
    public GreekGod[] godArray = new GreekGod[12];
    private int[] godCounts;
    public GameObject[] NFTs = new GameObject[12];
    public GameObject[] NFTCanvas;

    public TMP_Text collectedGodsText; // Assign the Text component in the Inspector
    public static int NFTsCollected = 0;
    public TMP_Text NftsCollected_Text;
    public static void NftAdded()
    {
        NFTsCollected++;
    }
    private void Update() {
        NftsCollected_Text.text = "NFTs Collected: " + NFTsCollected.ToString();
    }
    
    private void Start()
    {
        godCounts = new int[godArray.Length];
        collectedGodsText.text  = "NFTs: ";
        UpdateCollectedGodsText();
    }

    public void CollectGod(int godIndex)
    {
        if (godIndex >= 0 && godIndex < godArray.Length)
        {
            godCounts[godIndex]++;
            NFTs[godIndex].SetActive(false);
            NFTCanvas[godIndex].SetActive(false);
            UpdateCollectedGodsText();
        }
        else
        {
            Debug.LogWarning("Invalid god index: " + godIndex);
        }
    }

    private void UpdateCollectedGodsText()
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < godArray.Length; i++)
        {
            if (godCounts[i] > 0)
            {
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }
                builder.Append(godArray[i].ToString());
                builder.Append(": ");
                builder.Append(godCounts[i]);
            }
        }

        collectedGodsText.text = builder.ToString();
    }
}
