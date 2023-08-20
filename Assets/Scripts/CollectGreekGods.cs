using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    public GameObject IsraelGod;
    public GameObject StTimeline;
    public TMP_InputField TokentoMint_IP;
    int TokentoMint = 0;
    public GameObject NFTNameText,TotalNFTText;
    public TMP_Text Messege;

    public TMP_Text collectedGodsText; // Assign the Text component in the Inspector
    public static int NFTsCollected = 0;
    public TMP_Text NftsCollected_Text;
    bool TimelineComplete = false;
    public static void NftAdded()
    {
        NFTsCollected++;
    }
    private void Update() {
        if(NFTsCollected == 4 && TimelineComplete==false)
        {
            PlayTimeline();
        }
        TokentoMint = int.Parse(TokentoMint_IP.text);
        NftsCollected_Text.text = "NFTs Collected: " + NFTsCollected.ToString();
    }
    
    private void Start()
    {
        godCounts = new int[godArray.Length];
        collectedGodsText.text  = "NFTs: ";
        IsraelGod.SetActive(false);
        StTimeline.SetActive(false);
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
    public void PlayTimeline()
    {
        NFTNameText.SetActive(false);
        TotalNFTText.SetActive(false);
        StTimeline.SetActive(true);
        StartCoroutine(DelayTime(5));
        
        IsraelGod.SetActive(true);
        TimelineComplete = true;
        TotalNFTText.SetActive(true);
        NFTNameText.SetActive(true);
    }
    private IEnumerator DelayTime(float t)
    {
        yield return new WaitForSeconds(t);
        StTimeline.SetActive(false);
        Messege.text = "";
    }
    public void SendToken()//Called when you press SendToeken Button
    {
        Messege.text = "You have minted "+ TokentoMint.ToString();
        StartCoroutine(DelayTime(2));
        
    }
}
