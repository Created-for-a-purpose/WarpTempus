using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using TMPro;
using Thirdweb;

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
    string nftAddress="0x0486978C6608FBF91Af62815bBFC7f60F3016954";
    string nftAbi="[{\"inputs\":[{\"internalType\":\"string\",\"name\":\"name\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"symbol\",\"type\":\"string\"},{\"internalType\":\"uint256\",\"name\":\"_price\",\"type\":\"uint256\"}],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"approved\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"ApprovalForAll\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"}],\"name\":\"balanceOf\","
    +"\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"getApproved\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"}],\"name\":\"isApprovedForAll\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"ownerOf\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},"
    +"{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"setApprovalForAll\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes4\",\"name\":\"interfaceId\",\"type\":\"bytes4\"}],\"name\":\"supportsInterface\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"tokenURI\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"totalSupply\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"}],\"name\":\"safeMint\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"payable\",\"type\":\"function\"}]";
    
    public static void NftAdded()
    {
        NFTsCollected++;
    }
    private void Update() {
        if(NFTsCollected == 3 && TimelineComplete==false)
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
    public async void CollectGod(int godIndex){
        string tba = AnubisManager.PlayerTba;
        var sdk = ThirdwebManager.Instance.SDK;
        Contract nftContract = sdk.GetContract(nftAddress, nftAbi);
        try{
        await nftContract.ERC721.MintWRTTo(tba);
        } catch(System.Exception e){
            Debug.Log(e);
        }

        _collectGod(godIndex);
    }
    public void _collectGod(int godIndex)
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
