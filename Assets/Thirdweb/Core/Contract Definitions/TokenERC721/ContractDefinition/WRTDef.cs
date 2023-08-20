using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Thirdweb.Contracts.WRT.ContractDefinition
{
    public partial class MintToFunction : MintToFunctionBase { }
    
      [Function("safeMint")]
    public class MintToFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
    }

    public partial class CreateAccountFunction : CreateAccountFunctionBase { }

    [Function("createAccount")]
    public class CreateAccountFunctionBase : FunctionMessage
    {
        [Parameter("address", "implementation", 1)]
        public virtual string Implementation { get; set; }
        [Parameter("uint256", "chainId", 2)]
        public virtual BigInteger ChainId { get; set; }
        [Parameter("address", "tokenContract", 3)]
        public virtual string TokenContract { get; set; }
        [Parameter("uint256", "tokenId", 4)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "salt", 5)]
        public virtual BigInteger Salt { get; set; }
        [Parameter("bytes", "initData", 6)]
        public virtual byte[] InitData { get; set; }
    }
}