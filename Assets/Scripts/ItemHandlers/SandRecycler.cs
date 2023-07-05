using System;
using System.Collections.Generic;
using UnityEngine;

public class SandRecycler : MonoBehaviour, IStorage, IDispenser
{
	[SerializeField] private Currency _currencyPrefab;
	[SerializeField] private int _sandCount;

	private Queue<Sand> _sandForRecycling;

	private List<Currency> _currencyStorage;

	public bool HasFreeSpace => _sandForRecycling.Count < _sandCount;

	private void Start()
	{
		_sandForRecycling = new Queue<Sand>();
		_currencyStorage = new List<Currency>();
	}

	public void PlaceItem(Item item)
	{
		item.transform.parent = transform;
		item.transform.localRotation = Quaternion.identity;
		item.transform.localPosition = _sandForRecycling.Count * 0.1f * Vector3.up;
	}

	public bool TryDispensingInStorage(out Item item, IStorage storage)
	{
		for (int i = 0; i < _currencyStorage.Count; i ++)
		{
			if (storage.TryStore(_currencyStorage[i]))
			{
				item = _currencyStorage[i];
				_currencyStorage.RemoveAt(i);
				return true;
			}
		}

		item = null;
		return false;
	}

	public bool TryStore(Item item)
	{
		if (item is Sand sand)
		{
			_sandForRecycling.Enqueue(sand);
			StartRecycle();
			return true;
		}
		else
			return false;
	}

	private void StartRecycle()
	{
		if (_sandForRecycling.Count == 0) return;

		var sand = _sandForRecycling.Dequeue();
		Destroy(sand);

		var currency = Instantiate(_currencyPrefab, transform);

		_currencyStorage.Add(currency);
	}
}
