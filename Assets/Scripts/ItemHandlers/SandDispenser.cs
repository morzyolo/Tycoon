using System.Collections.Generic;
using UnityEngine;

public class SandDispenser : MonoBehaviour, IDispenser
{
	[SerializeField] private int _itemsCount;
	[SerializeField] private Transform _container;

	private Stack<CarriableItem> _storedItems;

	private void Start()
	{
		_storedItems = new Stack<CarriableItem>();
	}

	public bool TryDispense(out CarriableItem carriableItem)
	{
		_storedItems.TryPop(out carriableItem);
		return carriableItem != null;
	}

	public bool TryRefill(CarriableItem carriableItem)
	{
		if (_itemsCount == _storedItems.Count) return false;

		carriableItem.transform.parent = _container;
		carriableItem.transform.localPosition = CalculateItemPosition();
		carriableItem.transform.rotation = Quaternion.identity;
		_storedItems.Push(carriableItem);
		return true;
	}

	private Vector3 CalculateItemPosition()
	{
		return new Vector3(0f, _storedItems.Count * 0.4f, 0f);
	}
}
