using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraveYardSceneManager : MonoBehaviour
{
    public static int NFTsCollected = 0;
    public TMP_Text NftsCollected_Text;
    public static void NftAdded()
    {
        NFTsCollected++;
    }
    private void Update() {
        NftsCollected_Text.text = "NFTs Collected: " + NFTsCollected.ToString();
    }
}
