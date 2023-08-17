require('dotenv').config();
const { MNEMONIC, INFURA_API_KEY, ETHERSCAN_API_KEY } = process.env;

const HDWalletProvider = require('@truffle/hdwallet-provider');

module.exports = {
  contracts_build_directory: "./Assets/contracts",

  networks: {

    LineaGoerli: {
      provider: () => new HDWalletProvider(MNEMONIC, `https://linea-goerli.infura.io/v3/${INFURA_API_KEY}`),
      network_id: 59140,
      confirmations: 2,    // # of confs to wait between deployments. (default: 0)
      timeoutBlocks: 200,  // # of blocks before a deployment times out  (minimum/default: 50)
      skipDryRun: true , 
      
      verify: {
        apiUrl: "https://api-testnet.lineascan.build/api",        
        apiKey: ETHERSCAN_API_KEY,
        explorerUrl: "https://goerli.lineascan.build/address",      
      },
      network_id: "59140",
    },

  },

  // Configure your compilers
  compilers: {
    solc: {
      version: "0.8.10",  
    }
  },

  plugins: ["truffle-plugin-verify"],

};
