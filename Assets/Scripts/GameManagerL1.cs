using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MetaMask.Unity;
using Thirdweb;
using Nethereum.Util;

public class GameManagerL1 : MonoBehaviour
{
    public GameObject Door1;
    private Animator doorAnimator;
    private bool isCursorLocked = true;
    public static int balance;
    public static int puzzlesolved = 0;
    public TMP_Text puzzlescore;
    public TMP_Text t_balance;
    public TMP_Text publicKey;
    public GameObject Teleporter;
    public GameObject PuzzleScorePanel;
    public GameObject TimelineTeleporter;
    public GameObject metamaskInfo;
    public GameObject Chest;
    public GameObject ChestOpenPanel;
    bool TimelineComplete = false;
     string nftAddress="0x0486978C6608FBF91Af62815bBFC7f60F3016954";
     string nftAbi="[{\"inputs\":[{\"internalType\":\"string\",\"name\":\"name\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"symbol\",\"type\":\"string\"},{\"internalType\":\"uint256\",\"name\":\"_price\",\"type\":\"uint256\"}],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"approved\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"ApprovalForAll\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"}],\"name\":\"balanceOf\","
    +"\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"getApproved\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"}],\"name\":\"isApprovedForAll\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"ownerOf\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},"
    +"{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"},{\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"safeTransferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"operator\",\"type\":\"address\"},{\"internalType\":\"bool\",\"name\":\"approved\",\"type\":\"bool\"}],\"name\":\"setApprovalForAll\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"bytes4\",\"name\":\"interfaceId\",\"type\":\"bytes4\"}],\"name\":\"supportsInterface\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"tokenURI\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"tokenId\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"totalSupply\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"}],\"name\":\"safeMint\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"payable\",\"type\":\"function\"}]";
    
    private void Start()
    {
        balance = 0;
        LockUnlockCursor();
        doorAnimator = Door1.GetComponent<Animator>();
    }
    private void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
    public static void AddPoints()
    {
        balance += 5;
    }
    private void Update()
    {
        t_balance.text = "TGM: " + balance.ToString();
        puzzlescore.text = "Puzzle Solved: "+puzzlesolved.ToString();
        // Add any other input handling or game logic here

        // For example, you can press the "Escape" key to toggle cursor lock
        if (Input.GetKeyDown(KeyCode.M))
        {
            isCursorLocked = !isCursorLocked;
            LockUnlockCursor();
        }
        if(puzzlesolved == 2 && TimelineComplete==false)
        {
            PlayTeleporterTimeline();
        }
        if(puzzlesolved == 1)
        {
            Chest.SetActive(true);
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
    public async void OpenDoor()
    {
        // var wallet = MetaMaskUnity.Instance.Wallet;
        // wallet.Connect();
        Debug.Log("OpenDoor");
        string address = await ThirdwebManager.Instance.SDK.wallet.Connect(new WalletConnection(
            WalletProvider.Metamask,
            591430
        ));
        Debug.Log("This is the address: "+address);
        
    }
    public void openDoor(){
        doorAnimator.SetBool("OpenDoor", true);
        StartCoroutine(DeactivateAfterTimeCoroutine(2, Door1));
    }
    public void updateInfo(){
        metamaskInfo.SetActive(true);
        var pk = MetaMaskUnity.Instance.Wallet.SelectedAddress;
        publicKey.text = pk.Substring(0, 6) + "..." + pk.Substring(pk.Length - 4, 4);
    }
    public async void logBalance(){
         // 
        var balance = await ThirdwebManager.Instance.SDK.wallet.GetBalance();
        Debug.Log("Balance: " + balance);
        //
    }
    public void OnDisconnect(){
        publicKey.text = "Not Connected";
    }
    private IEnumerator DeactivateAfterTimeCoroutine(float t,GameObject gb)
    {
        yield return new WaitForSeconds(t);
        gb.SetActive(false);
    }
    private IEnumerator DelayTime(float t)
    {
        yield return new WaitForSeconds(t);
        TimelineTeleporter.SetActive(false);
    }
    public void PlayTeleporterTimeline()
    {
        PuzzleScorePanel.SetActive(false);
        Debug.Log("PlayTeleporterTimeline");
        TimelineTeleporter.SetActive(true);
        StartCoroutine(DelayTime(5));
        
        Teleporter.SetActive(true);
        TimelineComplete = true;
        PuzzleScorePanel.SetActive(false);
    }
    public async void mint(float price){
        var sdk = ThirdwebManager.Instance.SDK;
        Contract nftContract = sdk.GetContract(nftAddress, nftAbi);
        var add = await sdk.wallet.GetAddress();
        if(price == 0)
        {
            try{
           await nftContract.ERC721.MintWRTTo(add);
            } catch(System.Exception e){
                Debug.Log(e);
            }
        }
        else{
          await nftContract.Write("safeMint", new TransactionRequest{
            value = UnitConversion.Convert.ToWei(price, UnitConversion.EthUnit.Ether).ToString()
          }, add);
        }
    }
}
