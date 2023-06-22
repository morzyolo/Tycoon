using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
	[Header("Count")]
	[SerializeField] private int _itemsCount;
	[SerializeField] private Vector2Int _dimension;

	[Header("Offsets")]
	[SerializeField] private Vector3 _firstElemetOffset;
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

	public Vector3 CalculateItemPosition()
	{
		float y = _firstElemetOffset.y + _newItemId / (_dimension.x * _dimension.y) * _offsetBetweenItems.y;
		int _idInXZ = _newItemId % (_dimension.x * _dimension.y);
		float x = _firstElemetOffset.x + _idInXZ / _dimension.x * _offsetBetweenItems.x;
		float z = _firstElemetOffset.z + _idInXZ % _dimension.y  * _offsetBetweenItems.z;

		return new Vector3(x, y, z);
	}
}
