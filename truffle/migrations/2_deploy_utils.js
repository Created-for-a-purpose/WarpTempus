const Forwarder = artifacts.require("Forwarder");
const ERC6551Account = artifacts.require("ERC6551Account");
const ERC6551Registry = artifacts.require("ERC6551Registry");

module.exports = async function (deployer,_, accounts) {
  
    deployer.deploy(Forwarder,
        {from: accounts[1]});

  deployer.deploy(ERC6551Account,
    {from: accounts[1]});
   
    deployer.deploy(ERC6551Registry,
        {from: accounts[1]});

};