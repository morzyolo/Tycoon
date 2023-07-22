using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuyableNodesWrapper
{
	[SerializeField] private List<BuyableNode> _buyableNodes;

	public List<BuyableNode> BuyableNodes { get => _buyableNodes; set => _buyableNodes = value; }

	public BuyableNodesWrapper(List<BuyableNode> buyableNodes) => BuyableNodes = buyableNodes;
}
