using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Thirdweb;
using MetaMask.Unity;
using MetaMask.Models;

public class MCQQuestionSystem : MonoBehaviour
{
    public GameObject questionPanel;
    public GameObject correctAnswerPanel;
    public GameObject wrongAnswerPanel;
    public GameObject PuzzleSpot;
    public GameObject publicscorepanel;
    public TMP_Dropdown dropdown;
    public GameObject[] objectsToAppear; 
    public GameObject QuestionCanvas;   
    public int correctOptionIndex;
    bool isCorrect = false;
    string address = "0x55F17175ce6Fa9f6573f953DdF2827Fb6e270B25";
    string abi = "[{\"inputs\":[{\"internalType\":\"string\",\"name\":\"_name\",\"type\":\"string\"},{\"internalType\":\"string\",\"name\":\"_symbol\",\"type\":\"string\"},{\"internalType\":\"uint256\",\"name\":\"_totalSupply\",\"type\":\"uint256\"}],\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"spender\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"name\":\"allowance\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\",\"constant\":true},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\",\"constant\":true},{\"inputs\":[],\"name\":\"decimals\",\"outputs\":"
    +"[{\"internalType\":\"uint8\",\"name\":\"\",\"type\":\"uint8\"}],\"stateMutability\":\"view\",\"type\":\"function\",\"constant\":true},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\",\"constant\":true},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\",\"constant\":true},{\"inputs\":[],\"name\":\"totalSupply\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\",\"constant\":true},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"_to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"_value\",\"type\":\"uint256\"}],\"name\":\"transfer\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"success\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"_spender\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"_value\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"success\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"_from\",\"type\":\"address\"},{\"internalType\":\"address\",\"name\":\"_to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"_value\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"success\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"_to\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"_value\",\"type\":\"uint256\"}],\"name\":\"claim\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"success\",\"type\":\"bool\"}],\"stateMutability\":\"nonpayable\",\"type\":\"function\"}]";
    
    private void Start()
    {
        // Hide all panels initially
        questionPanel.SetActive(true);
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(false);
    }

    public void SubmitAnswer()
    {
        int selectedOptionIndex = dropdown.value;

        if (selectedOptionIndex == correctOptionIndex)
        {
            ShowCorrectAnswerPanel();
        }
        else
        {
            ShowWrongAnswerPanel();
        }
    }
    private async void initiateClaim(){
        var sdk = ThirdwebManager.Instance.SDK;
        Contract contract = sdk.GetContract(address, abi);
        var add = await sdk.wallet.GetAddress();
        // await contract.Write("claim", add, 5);
        try{
        await contract.ERC20.MintTGMTo(add, "5");
        }
        catch(System.Exception e){
            Debug.Log(e);
        }
            GameManagerL1.AddPoints();
            addTokenToMetamask();
    }
    private async void addTokenToMetamask(){
        var wallet = MetaMaskUnity.Instance.Wallet;
        
        var request = new MetaMaskEthereumRequest{
                Method = "wallet_watchAsset",
                Parameters = new MetaMaskParameters{ 
                        Type = "ERC20",
                        Options = new MetaMaskOptions{
                            Address = address,
                            Symbol = "TGM",
                            Decimals = 18,
                            Image = "https://cdn.dribbble.com/users/623914/screenshots/17252125/media/8b988bf690f135d8ca18c3d65dfa59b2.jpg?resize=400x300&vertical=center"
                        }
                    }
                };
        await wallet.Request(request);
    }
    public void Next()
    {
        questionPanel.SetActive(false);
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(false);
        PuzzleSpot.SetActive(false);
        foreach (GameObject obj in objectsToAppear)
            {
                obj.SetActive(true);
            }
        QuestionCanvas.SetActive(false);
        publicscorepanel.SetActive(true);
        if(isCorrect)
        {
            initiateClaim();
            GameManagerL1.puzzlesolved++;
        }
    }

    private void ShowCorrectAnswerPanel()
    {
        isCorrect = true;
        questionPanel.SetActive(false);
        correctAnswerPanel.SetActive(true);
        wrongAnswerPanel.SetActive(false);
    }

    private void ShowWrongAnswerPanel()
    {
        questionPanel.SetActive(false);
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(true);
    }

    public void ShowQuestionPanel()
    {
        questionPanel.SetActive(true);
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(false);
    }
}
