using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buyable object/Node", menuName = "Buyable object/Node", order = 2)]
public class BuyableNode : ScriptableObject
{
	[Header("Cost")]
	[SerializeField] private int _cost;
	[SerializeField] private CurrencyType _costType;

	[Header("Spawn values")]
	[SerializeField] private Vector3 _spawnPoint;
	[SerializeField] private Vector3 _triggerPoint;
	[SerializeField] private GameObject _spawnedObject;

	[Space(15)]
	[SerializeField] private List<BuyableNode> _nextBuyableNodes;

	public int Cost { get => _cost; }
	public CurrencyType CostType { get => _costType; }

	public Vector3 SpawnPoint { get => _spawnPoint; }
	public Vector3 TriggerPoint { get => _triggerPoint; }
	public GameObject SpawnedObject { get => _spawnedObject; }

	public List<BuyableNode> NextBuyableNodes { get => _nextBuyableNodes; }
}
