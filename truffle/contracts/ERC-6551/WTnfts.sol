// SPDX-License-Identifier: MIT
pragma solidity ^0.8.9;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";
import "@openzeppelin/contracts/utils/Counters.sol";

contract WTnfts is ERC721 {
    uint256 price;
    using Counters for Counters.Counter;
    Counters.Counter private tokenIds;

    constructor(string memory name, string memory symbol, uint256 _price) ERC721(name, symbol) {
        price = _price;
    }

    function totalSupply() public view returns (uint256) {
        return tokenIds.current();
    }

    function safeMint(address to) payable public returns(uint256) {
        require(msg.value >= price, "Not enough ETH sent; check price!");
        uint256 tokenId = tokenIds.current();
        _safeMint(to, tokenId);
        tokenIds.increment();
        return tokenId;
    }
}