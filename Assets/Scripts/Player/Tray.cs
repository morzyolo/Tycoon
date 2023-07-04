using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour, IDispenser
{
	public bool HasFreeSpace => _carriableItems.Count < _itemsCount;

	[Header("Count")]
	[SerializeField] private int _itemsCount;
	[SerializeField] private Vector2Int _dimension;

	[Header("Offsets")]
	[SerializeField] private Vector3 _firstElementOffset;
	[SerializeField] private Vector3 _offsetBetweenItems;

	private List<CarriableItem> _carriableItems;

	public void Initialize()
	{
		_carriableItems = new List<CarriableItem>(_itemsCount);
	}

	public void Store(CarriableItem item)
		=> _carriableItems.Add(item);

	public bool TryDispense(out Item item, IStorage storage)
	{
		foreach (var i in _carriableItems)
		{
			if (storage.TryStore(i))
			{
				item = i;
				_carriableItems.Remove(i);
				return true;
			}
		}

		item = null;
		return false;
	}

	public void PlaceItem(Item item)
	{
		item.transform.parent = transform;
		item.transform.localRotation = Quaternion.identity;
		item.transform.localPosition = CalculateItemPosition(_carriableItems.Count - 1);
	}

	private Vector3 CalculateItemPosition(int itemId)
	{
		float y = _firstElementOffset.y + itemId / (_dimension.x * _dimension.y) * _offsetBetweenItems.y;
		int _idInXZ = itemId % (_dimension.x * _dimension.y);
		float x = _firstElementOffset.x + _idInXZ / _dimension.x * _offsetBetweenItems.x;
		float z = _firstElementOffset.z + _idInXZ % _dimension.y  * _offsetBetweenItems.z;

		return new Vector3(x, y, z);
	}
}
