using System.Collections.Generic;
using UnityEngine;

public class BuyableObject : MonoBehaviour, IBuyable
{
	[SerializeField] private BuyableObjectNode _node;

	public void Buy()
	{
		Instantiate(_node.SpawnObject, _node.SpawnPoint, Quaternion.identity);
		gameObject.SetActive(false);
	}

	public KeyValuePair<CurrencyType, int> GetCost() => new(_node.CostType, _node.Cost);
}
