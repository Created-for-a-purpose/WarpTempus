const Token1 = artifacts.require("Token");
const Token2 = artifacts.require("Token");
const nft = artifacts.require("WTnfts");
require("dotenv").config();

module.exports = async function (deployer,_, accounts) {

  deployer.deploy(Token1,
    "TimeGems",
    "TGM",
    1000,
    {from: accounts[1]});
   
    deployer.deploy(Token2,
        "WarpOrbs",
        "WRB",
        1000,
        {from: accounts[1]});

    deployer.deploy(nft,
        "WarpTime",
        "WRT",
        0,
        {from: accounts[1]});

    
};