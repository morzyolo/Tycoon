using System.Collections.Generic;
using UnityEngine;

public class ItemDispenser : MonoBehaviour, IDispenser
{
	[SerializeField] private int _itemsCount;

	private List<Item> _storedItems;

	private void Start()
	{
	 	_storedItems = new List<Item>();
	}

	public bool TryDispense(out Item item, IStorage storage)
	{
		foreach (Item i in _storedItems)
		{
			if (storage.TryStore(i))
			{
				item = i;
				_storedItems.Remove(i);
				return true;
			}
		}

		item = null;
		return false;
	}

	public bool HasFreeSpace => _storedItems.Count < _itemsCount;

	public void Store(Item item)
	{
		item.transform.parent = this.transform;
		item.transform.localPosition = new Vector3(0, 0.5f + _storedItems.Count * 0.2f, 0);
		_storedItems.Add(item);
	}
}
