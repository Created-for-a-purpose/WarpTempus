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

namespace Thirdweb.Contracts.TGM.ContractDefinition
{
    public partial class MintToFunction : MintToFunctionBase { }
    
      [Function("claim")]
    public class MintToFunctionBase : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public virtual string To { get; set; }

        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Amount { get; set; }
    }
}