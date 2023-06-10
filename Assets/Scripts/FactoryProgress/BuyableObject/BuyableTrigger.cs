using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BuyableTrigger : MonoBehaviour, IBuyable
{
	private event Action<BuyableTrigger, BuyableNode> ObjectBought;

	private BuyableNode _node;

	public void Initialize(BuyableNode node, Action<BuyableTrigger, BuyableNode> bought)
	{
		SetNode(node);
		ObjectBought = bought;
	}

	public void SetNode(BuyableNode node)
	{
		_node = node;
		transform.localPosition = _node.TriggerPoint;
	}

	public void Buy()
	{
		ObjectBought?.Invoke(this, _node);
	}

	public KeyValuePair<CurrencyType, int> GetCost() => new(_node.CostType, _node.Cost);
}
