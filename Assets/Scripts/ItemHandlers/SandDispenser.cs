using System.Collections.Generic;
using UnityEngine;

public class SandDispenser : MonoBehaviour, IDispenser
{
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
}
