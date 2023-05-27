using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buyable object/Node", menuName = "Buyable object/Node", order = 2)]
public class BuyableObjectNode : ScriptableObject
{
	[Header("Cost")]
	[SerializeField] private int _cost;
	[SerializeField] private CurrencyType _costType;

	[Header("Spawn values")]
	[SerializeField] private Vector3 _spawnPoint;
	[SerializeField] private GameObject _spawnObject;

	[Space(15)]
	[SerializeField] private List<BuyableObject> _nextBuyableObjects;

	public int Cost { get => _cost; }
	public CurrencyType CostType { get => _costType; }

	public Vector3 SpawnPoint { get => _spawnPoint; }
	public GameObject SpawnObject { get => _spawnObject; }

	public List<BuyableObject> NextBuyableObjects { get => _nextBuyableObjects; }
}
