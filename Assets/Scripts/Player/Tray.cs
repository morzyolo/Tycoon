using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
	public bool HasFreeSpace => _newItemId < _itemsCount;

	[Header("Count")]
	[SerializeField] private int _itemsCount;
	[SerializeField] private Vector2Int _dimension;

	[Header("Offsets")]
	[SerializeField] private Vector3 _firstElementOffset;
	[SerializeField] private Vector3 _offsetBetweenItems;

	private int _newItemId;
	private List<CarriableItem> _carriableItems;

	public void Initialize()
	{
		_newItemId = 0;
		_carriableItems = new List<CarriableItem>(_itemsCount);
	}

	public bool TryToCarryItem(CarriableItem carriable)
	{
		if (_newItemId == _itemsCount) return false;

		carriable.transform.parent = this.transform;
		carriable.transform.localPosition = CalculateItemPosition();
		carriable.transform.localRotation = Quaternion.identity;
		_carriableItems.Add(carriable);
		_newItemId++;
		return true;
	}

	private Vector3 CalculateItemPosition()
	{
		float y = _firstElementOffset.y + _newItemId / (_dimension.x * _dimension.y) * _offsetBetweenItems.y;
		int _idInXZ = _newItemId % (_dimension.x * _dimension.y);
		float x = _firstElementOffset.x + _idInXZ / _dimension.x * _offsetBetweenItems.x;
		float z = _firstElementOffset.z + _idInXZ % _dimension.y  * _offsetBetweenItems.z;

		return new Vector3(x, y, z);
	}
}
