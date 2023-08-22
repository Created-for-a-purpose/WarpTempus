# WarpTempus
Warp Tempus is a web3 powered Windows game made using Unity, which allows gamers to explore different worlds, solve puzzles, collect artifacts and receive amazing rewards.

## Problems addressed 

### User adoption: Gas fee is a hassle to the users new to Web3

Warp Tempus facilitates gasless transactions for all in-game blockchain interactions, providing a seamless, hassle-free experience to the players.
This is crucial to onboard new users to the world of Web3.

### Restricted composability and inconvenient management of ERC-721 tokens

In most web3 games, as a player progresses, it accumulates various in-game onchain assets, which become difficult to manage over time as they exist as separate entities in the wallet. 
Warp Tempus leverages ERC-6551 NFTs (Token Bound Accounts) to bundle onchain in-game assets together to make reward management easier and to enhance composability.

# Get Started
Welcome to the world of Tempus! Once the game starts you will be spawned in front of a giant door, you have to open it!
### Login
Login to the game by scanning the QR using your metamask mobile. This login functionality is implemented using the Metamask Unity SDK.

![Screenshot 2023-08-22 063325](https://github.com/Created-for-a-purpose/WarpTempus/assets/97793907/bb3fc1e3-7e59-43a8-a4ab-051d1ca7bcd1)

On successful login, the door will open and you will see your connected metamask account address at the top-left corner.
### Exploration (About Gasless transactions)
There is a map to guide with certain symbols to guide you. Reach the symbols and you will unlock new challenges and possibilities.

![image](https://github.com/Created-for-a-purpose/WarpTempus/assets/97793907/2e9ea47d-ae1d-4ffe-b28d-10f9191ffd49)

On hitting these question marks, you will be confronted with some puzzles. Answer them correctly to claim rewards (TGM tokens). TGM are the native ERC20 tokens of Warp Tempus. 

Claiming tokens requires you to pay a gas fee, but relax! you have got to pay nothing (zero gas) to claim your rewards. Just sign the transaction and TGM tokens will automatically be credited to your connected account. These gasless transactions are implemented using the Thirdweb Unity SDK and OpenZeppelin Defender.

![image](https://github.com/Created-for-a-purpose/WarpTempus/assets/97793907/92ab3f7e-8b8c-4a4e-aaf9-67cd5e6469a2)

Want to see your TGM tokens in your metamask wallet? Don't worry you do not have to deal with complex contract addresses. We have implement auto add tokens using Metamask's ethereum request "wallet_watchAsset".

![image](https://github.com/Created-for-a-purpose/WarpTempus/assets/97793907/f3f16828-0058-4335-bbca-78ce64825c29)

### New possibilities

After solving some puzzles, you would unlock a rare treasure chest. The chest contains some precious elements, you will need in further levels!

![image](https://github.com/Created-for-a-purpose/WarpTempus/assets/97793907/9f92fc75-d82b-4fdf-8aa2-2125b543315f)

You can pick any 1 one of them, choose wisely ! It will be minted as an NFT to your connected account.

After solving even more puzzles, you will unlock a new level. A portal will be displayed to you, you just have to hit it and... booom ! you will reach another world with new challenges.

### Next world (About ERC-6551 NFTs)
On reaching the new level, you will be given a task to search for some artifacts. These artifacts will be minted to you as NFTs because you found them, however, managing so many onchain in-game assets can be quite a hassle!
Don't worry! Anubis is here. After minting the Anubis NFT, a Token Bound Account (TBA) will created for it. This will make it an ERC-6551 NFT.

![image](https://github.com/Created-for-a-purpose/WarpTempus/assets/97793907/567cc5c6-ab13-45f0-b6c9-6fd212e06731)

After successfully creating the Token Bound Account (TBA), all the artifacts you find will be minted as NFTs to your Anubis NFT's token bound account. This will not only help you manage your onchain game assets with ease but will also enhance composability. Your ERC-6551 NFT (Anubis) will represent the artifacts you found and hence unique capabilities.

![Screenshot 2023-08-22 064554](https://github.com/Created-for-a-purpose/WarpTempus/assets/97793907/192c684e-07a7-46ff-a548-4825c2eee56f)

After successfully founding some artifacts, a new feature will be unlocked!

![image](https://github.com/Created-for-a-purpose/WarpTempus/assets/97793907/e910173d-d4d7-4849-aefc-e231d441bab5)

### Liquidity Pool (Coming Soon)

![image](https://github.com/Created-for-a-purpose/WarpTempus/assets/97793907/cf3fe4dc-fe01-4ffd-a790-68e98ad0a4cd)


## Smart Contract links on blockscout:
1. TGM tokens: https://explorer.goerli.linea.build/address/0x55F17175ce6Fa9f6573f953DdF2827Fb6e270B25
2. NFTs: https://explorer.goerli.linea.build/address/0x0486978C6608FBF91Af62815bBFC7f60F3016954
3. Forwarder (For gasless txs): https://explorer.goerli.linea.build/address/0x708644Acf99c1b5631DC1157cfCe14f7DEaBbf0f
4. ERC-6551 Registry: https://explorer.goerli.linea.build/address/0x29fD08fcFcA70dF833bA2963C75D04A317A2c118
5. ERC-6551 Account (Implementation): https://explorer.goerli.linea.build/address/0xAd875b392C619fA798CeF148a88db586796E0C35
6. ERC-6551 Account (TBA used above): https://explorer.goerli.linea.build/address/0x79783D2a81f0A69019081F0D7C09395131Ac6ec3/token-transfers#address-tabs






