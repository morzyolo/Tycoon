using System;
using System.Collections.Generic;
using UnityEngine;

public class FactoryProgress : MonoBehaviour
{
	private event Action<BuyableTrigger, BuyableNode> NodeBought;

	[SerializeField] private BuyableNode _startNode;
	[SerializeField] private BuyableTrigger _buyableTriggerPrefab;

	private List<BuyableNode> _buyableNodes;
	private Stack<BuyableTrigger> _triggerPool;

	private FileDataHandler _fileHandler;

	public void Initialize(FileDataHandler fileHandler)
	{
		_fileHandler = fileHandler;
		_buyableNodes = _fileHandler.LoadBuyableNodesData();
		InitializeNodes();
	}

	private void InitializeNodes()
	{
		_triggerPool = new Stack<BuyableTrigger>();

		if (_buyableNodes == null || _buyableNodes.Count == 0)
		{
			_buyableNodes = new List<BuyableNode>();
			SpawnTrigger(_startNode);
		}
		else
		{
			SpawnObject(_startNode);
			CheckNextNodes(_startNode.NextBuyableNodes);
		}
	}

	private void SpawnTrigger(BuyableNode node) =>
		Instantiate<BuyableTrigger>(_buyableTriggerPrefab, this.transform)
		.Initialize(node, NodeBought);

	private void SpawnObject(BuyableNode node) =>
		Instantiate(node.SpawnedObject, node.SpawnPoint, Quaternion.identity, this.transform);

	private void CheckNextNodes(List<BuyableNode> nodes)
	{
		foreach (var node in nodes)
		{
			if (_buyableNodes.Contains(node))
			{
				SpawnObject(node);
				CheckNextNodes(node.NextBuyableNodes);
			}
			else
			{
				SpawnTrigger(node);
			}
		}
	}

	private void ActivateObject(BuyableTrigger trigger, BuyableNode node)
	{
		SpawnObject(node);
		_buyableNodes.Add(node);

		if (node.NextBuyableNodes.Count == 0)
		{
			_triggerPool.Push(trigger);
			trigger.gameObject.SetActive(false);
			return;
		}

		for (int i = 0; i < node.NextBuyableNodes.Count - 1; i++)
		{
			if (_triggerPool.Count > 0)
			{
				var tr = _triggerPool.Pop();
				tr.gameObject.SetActive(true);
				tr.SetNode(node.NextBuyableNodes[i]);
			}
			else
			{
				SpawnTrigger(node.NextBuyableNodes[i]);
			}
		}

		trigger.SetNode(node.NextBuyableNodes[^1]);
	}

	private void OnEnable()
	{
		NodeBought += ActivateObject;
	}

	private void OnDisable()
	{
		NodeBought -= ActivateObject;
	}
}
